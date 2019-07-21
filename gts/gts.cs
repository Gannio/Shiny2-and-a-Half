using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Web;

namespace gts
{

    #region enumerations

    /// <summary>
    /// The different generations this system supports.
    /// </summary>
    public enum Generation
    {
        IV,
        V
    }

    /// <summary>
    /// The different modes of operation the gts
    /// system can support.
    /// </summary>
    public enum Operation
    {
        GenIV = 0,
        GenV,
        Dual,
        ReceiveIV,
        ReceiveV,
        ReceiveDual
    }

    /// <summary>
    /// Additional Operating Options to be set.
    /// </summary>
    public enum OperationOptions
    {
        Individual,
        Folder
    }

    /// <summary>
    /// These are the different folder options
    /// for distribution.
    /// </summary>
    public enum FolderOptions
    {
        Ordered,
        Random
    }

    #endregion

    #region events

    public class GtsLogDataEventArgs : EventArgs
    {
        /// <summary>
        /// The logging data passed up.
        /// </summary>
        public string Data { get; set; }
    }

    public class GtsPokemonSentEventArgs : EventArgs
    {
        
        /// <summary>
        /// The total number of pokemon sent.
        /// </summary>
        public int NumberSent { get; set; }

        /// <summary>
        /// The game generation.
        /// </summary>
        public Generation GameGeneration { get; set; }

    }

    #endregion

    #region Gts

    public class Gts
    {

        #region properties

        #region operation

        /// <summary>
        /// Gets or sets the operation mode of this gts system.
        /// </summary>
        public Operation DistributionMode { get; set; }

        /// <summary>
        /// Gets or sets the mode of operation for distributions; whether it be folder or individual.
        /// </summary>
        public OperationOptions DistributionOptions { get; set; }

        /// <summary>
        /// Gets or sets if the system will distribute from a folder sequentially or randomly.
        /// </summary>
        public FolderOptions FolderOptions { get; set; }

        /// <summary>
        /// A custom string to display for the browser.
        /// </summary>
        public string BrowserMessage { get; set; }

        /// <summary>
        /// This will be the format of the tables that get displayed in the browser.
        /// </summary>
        public string TableFormat { get; set; }
        
        /// <summary>
        /// Configures the GTS to dump extra information.
        /// </summary>
        public bool DumpExtra { get; set; }

        /// <summary>
        /// A configurable option to show an online page.
        /// </summary>
        public bool ShowOnline { get; set; }

        #endregion

        #region folders

        /// <summary>
        /// The path for distributing generation 4 pokemon [folder].
        /// </summary>
        public string GenIVGiveFolder { get; set; }

        /// <summary>
        /// The path for distributing generation 5 pokemon [folder].
        /// </summary>
        public string GenVGiveFolder { get; set; }

        /// <summary>
        /// The path for receiving generation 4 pokemon [folder].
        /// </summary>
        public string GenIVGetFolder { get; set; }

        /// <summary>
        /// The path for receiving generation 5 pokemon [folder].
        /// </summary>
        public string GenVGetFolder { get; set; }

        #endregion

        #region files

        /// <summary>
        /// The generation 4 pokemon file to distribute.
        /// </summary>
        public string GenIVFile { get; set; }

        /// <summary>
        /// The generation 5 pokemon file to distribute.
        /// </summary>
        public string GenVFile { get; set; }

        #endregion

        #endregion

        #region variables

        private int _gen4Count;
        private int _gen5Count;

        public int receiveCount;//Gannio: Did this really hapazardly compared to above since I did it on a whim. If someone wants me to change this (and divide among gens) I should be able to, but give me a reason!

        public int getReceivedCount()
        {
            return receiveCount;
        }

        public int _gen5CountReceive;

        private int _gen4FolderCount = -1;
        private int _gen5FolderCount = -1;

        private bool _stop;

        private readonly List<Socket> _clients = new List<Socket>(); 
        private readonly Random _rnd = new Random();
        private readonly Encoding _dsEncoding = Encoding.GetEncoding("iso-8859-1");
        private Socket _gtsserver = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        private IAsyncResult _currentAsync;

        #endregion

        #region events
        
        public event GtsLogData GtsLog = delegate { };
        public event PokemonSentEventHandler GtsPokemonSent = delegate { };

        public event PokemonSentEventHandler GtsPokemonReceived = delegate { };
        /// <summary>
        /// Logging Event.
        /// </summary>
        /// <param name="sender">The object that has raised the event.</param>
        /// <param name="e">The event arguments that contain the log materials.</param>
        /// <remarks></remarks>
        public delegate void GtsLogData(object sender, GtsLogDataEventArgs e);

        /// <summary>
        /// Raised when a Pokemon is sent.
        /// </summary>
        /// <param name="sender">The object that has raised the event.</param>
        /// <param name="e">The event arguments that contain the generation and number sent.</param>
        /// <remarks></remarks>
        public delegate void PokemonSentEventHandler(object sender, GtsPokemonSentEventArgs e);

        /// <summary>
        /// Writes out events to the Gts Log.
        /// </summary>
        /// <param name="data">The data to write out.</param>
        /// <param name="extra">Indicates that the incoming data is extra bulk.</param>
        private void WriteLog(string data, bool extra = false)
        {
            if (extra && !DumpExtra)
                return;
            GtsLog(this, new GtsLogDataEventArgs {Data = data});
        }

        #endregion

        #region start/stop

        /// <summary>
        /// Initializes the GTS system.
        /// </summary>
        public void Start()
        {
            try
            {

                // restart
                _stop = false;

                // recreate everything.
                _gtsserver = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                _gtsserver.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, 1);

                // Bind and listen
                _gtsserver.Bind(new IPEndPoint(IPAddress.Any, 80));
                _gtsserver.Listen(int.MaxValue);
                _currentAsync = _gtsserver.BeginAccept(AcceptConnection, null);

                // log
                WriteLog("The GTS server has successfully initialized.");

            }
            catch (Exception e)
            {
                WriteLog("The GTS server has failed to initialize! Are your ports blocked?");
                WriteLog(e.ToString(), true);
            }


        }

        /// <summary>
        /// Safely shuts down the GTS system.
        /// </summary>
        public void Stop()
        {
            try
            {
                if (_stop)
                    return;
                WriteLog("Stopping the GTS system...");
                _stop = true;
                _gtsserver.Close();
                _gtsserver.Dispose();
                WriteLog("The GTS system has been stopped!");
                WriteLog(string.Format("{0} clients still connected...", _clients.Count), true);
            }
            catch (Exception e)
            {
                WriteLog(e.ToString());
            }

        }

        #endregion

        #region threading

        /// <summary>
        /// Accepts an incoming connection attempt.
        /// </summary>
        /// <param name="ir"></param>
        private void AcceptConnection(IAsyncResult ir)
        {
            
            // accept the incoming client.
            if (_gtsserver != null && !_stop && ir.IsCompleted && ir == _currentAsync)
            {

                try
                {

                    // derp along.
                    var client = _gtsserver.EndAccept(ir);

                    // can we keep listening?
                    if (!_stop)
                        _currentAsync = _gtsserver.BeginAccept(AcceptConnection, null);

                    // okay, make sure it's not null
                    if (client == null) return;

                    // Log
                    WriteLog("A connection has been established!");
                    WriteLog(string.Format("The connection is from {0}", client.RemoteEndPoint), true);

                    // add it to the client list.
                    lock (_clients)
                        _clients.Add(client);

                    // process
                    Handler(client);

                    // remove
                    client.Dispose();

                    // all done, kick it off
                    lock (_clients)
                        _clients.Remove(client);

                }
                catch (Exception) { }

            }
        }

        #endregion

        #region structures and sub classes

        private class Request
        {

            /// <summary>
            /// The action being performed on the GTS. This is technically the name of the page, minus the extension.
            /// </summary>
            public string Action { get; private set; }

            /// <summary>
            /// This is the page being visited, straight from the root of the request.
            /// </summary>
            public string PageFromRoot { get; private set; }

            /// <summary>
            /// A list of the variables sent during the transmission.
            /// </summary>
            public Dictionary<string, string> GetVars { get; private set; }

            /// <summary>
            /// The current game generation of the request.
            /// </summary>
            public Generation Generation { get; private set; }

            /// <summary>
            /// Creates a request and parses the given string.
            /// </summary>
            /// <param name="h">The string to parse.</param>
            public Request(string h)
            {

                // Fill default stuff.
                Action = string.Empty;
                PageFromRoot = string.Empty;
                GetVars = new Dictionary<string, string>();
                Generation = Generation.IV;

                // check for ds header
                if (!h.StartsWith("GET"))
                    return;

                // Trim out the GET
                h = h.Remove(0, 4).Trim();

                // Beautiful, now, get the string from here till the next gap.
                try
                {
                    PageFromRoot = h.Substring(1, h.IndexOf(' '));
                }
                catch (Exception)
                {
                    PageFromRoot = h.Substring(1);
                }

                //// Check and remove everything.
                //if(Page.Contains('/'))
                //    Page = Page.Remove(0, Page.IndexOf('/')).Trim();

                // Now check
                if (PageFromRoot.Contains('.'))
                {
                    Action = PageFromRoot.Split('.')[0].Trim().Remove(0, PageFromRoot.Contains('/') ? PageFromRoot.LastIndexOf('/') : 0);
                }

                // determine the generation
                Generation = h.Contains("pokemondpds") ? Generation.IV : Generation.V;

                // Now we have the page and action.
                // It's time to get some variables
                if(PageFromRoot.Contains('?'))
                {

                    // Get the actions.
                    var parameters = PageFromRoot.Split('?')[1];

                    // We've done that, now, split on the &
                    foreach (var parameterData in parameters.Split('&').Select(parameter => parameter.Split('=')))
                    {
                        // Add it to the keylist
                        GetVars.Add(parameterData[0], parameterData[1]);
                    }

                }

                //// We need t see if H even has a request
                //if(!h.Contains(".asp"))
                //{
                //    Action = string.Empty;
                //    Page = string.Empty;
                //}
                //else
                //{

                //    // okay, now split h up.
                //    foreach (var line in h.Split('/').Where(line => line.Contains("asp")))
                //    {
                //        Action = line.Split('.')[0];
                //        Page = line;
                //    }

                //    // grab the parameters & info.
                //    var pageName = h.Split('/').Where(line => line.Contains("asp")).ToList()[0].Split(' ')[0];

                //    // setup the dictionary
                //    GetVars = new Dictionary<string, string>();

                //    // Check to see if there are any parameters.
                //    if (pageName.Contains("?"))
                //    {

                //        // Get some parameters
                //        var param = pageName.Split('?')[1].Split(' ')[0];
                //        var info = param.Split('&');

                //        // add the different parameters.
                //        foreach (var s in info)
                //            GetVars.Add(s.Split('=')[0], s.Split('=')[1].Split(' ')[0]);

                //    }
                //}
            }

            /// <summary>
            /// Returns a string representation of the request.
            /// </summary>
            /// <returns></returns>
            public override string ToString()
            {
                return string.Format("Action: {0}\nPage: {1}\nGeneration: {2}", Action, PageFromRoot, Generation);
            }

        }
        public class Response
        {
            private string _data;

            private readonly List<string> _headers = new List<string>();


            public Response(string h)
            {
                if (!h.StartsWith("HTTP/1.1"))
                {
                    _data = h;
                }
                else
                {
                    _headers.AddRange(h.Split('\n'));
                    _data = string.Join(Environment.NewLine, _headers.ToArray());
                }


                //string line;

                //do {
                //    line = _headers[0];
                //    _headers.RemoveAt(0);

                //    if (line.StartsWith("P3P")) {
                //        _p3P = line.Substring(line.IndexOf(": ", StringComparison.Ordinal) + 2);
                //    }
                //    if (line.StartsWith("cluster-server")) {
                //        _server = line.Substring(line.IndexOf(": ", StringComparison.Ordinal) + 2);
                //    }
                //    if (line.StartsWith("X-Server-")) {
                //        _sname = line.Substring(line.IndexOf(": ", StringComparison.Ordinal) + 2);
                //    }
                //    if (line.StartsWith("Content-Length")) {
                //        _len = int.Parse(line.Substring(line.IndexOf(": ", StringComparison.Ordinal) + 2));
                //    }
                //    if (line.StartsWith("Set-Cookie")) {
                //        _cookie = line.Substring(line.IndexOf(": ", StringComparison.Ordinal) + 2);
                //    }
                //} while (!(string.IsNullOrEmpty(line)));


            }

            public override string ToString()
            {

                string[] days = {
                                    "Mon",
                                    "Tue",
                                    "Wed",
                                    "Thu",
                                    "Fri",
                                    "Sat",
                                    "Sun"
                                };

                var t = DateTime.Now;



                //"Content-type: application/octet-stream" & vbCrLf & _
                return (((((((((("HTTP/1.1 200 OK" + Environment.NewLine + "Date: " + days[Convert.ToInt32(t.DayOfWeek)] +
                                 ", " + t.Day + " " + t.Month + " " + t.Year + " " + t.Hour + ":" + t.Minute + ":" +
                                 t.Second + " GMT") + Environment.NewLine + "Server: Microsoft-IIS/6.0") +
                               Environment.NewLine + "P3P: CP='NOI ADMa OUR STP'") + Environment.NewLine +
                              "cluster-server: aphexweb3") + Environment.NewLine + "X-Server-Name: AW4") +
                            Environment.NewLine + "X-Powered-By: ASP.NET") + Environment.NewLine + "Content-Length: " +
                           _data.Length) + Environment.NewLine + "Content-Type: text/html") + Environment.NewLine +
                         "Set-Cookie: ASPSESSIONIDQCDBDDQS=JFDOAMPAGACBDMLNLFBCCNCI; path=/") + Environment.NewLine +
                        "Cache-control: private") + Environment.NewLine + Environment.NewLine + _data;
            }

            public string[] Getpkm()
            {
                var all = new List<string>();
                var dataTmp = _data;

                while (dataTmp.Length > 0)
                {
                    var result = _data.Substring(0, 292);
                    _data = _data.Substring(292);
                    all.Add(result.Substring(0, 136));
                }

                return all.ToArray();
            }

        }

        #endregion

        #region binary retrieval

        /// <summary>
        /// Prepares a Generation V Pokemon for transmission
        /// </summary>
        /// <param name="currentDataFileName">The path to the pokemon</param>
        /// <returns>Byte array()</returns>
        /// <remarks></remarks>
        private byte[] GetBin(string currentDataFileName)
        {
            byte[] bin = null;
            if (File.Exists(currentDataFileName))
            {
                var pkm = File.ReadAllBytes(currentDataFileName);

                if (pkm.Length < 220)
                    Array.Resize(ref pkm, 220);
                else if (pkm.Length > 220)
                    return null;

                bin = BW.Pokemon.EncryptPokemon((byte[]) pkm.Clone());

                var binEnd = new byte[60];
                Array.Copy(pkm, 8, binEnd, 0, 2);
                //ID
                binEnd[2] = Convert.ToByte((pkm[64] & 4) > 0 ? 3 : (pkm[64] & 2) + 1);
                //Gender
                binEnd[3] = pkm[140];
                //Level
                Array.Copy(new byte[]
                               {
                                   0x1,
                                   0x0,
                                   0x3,
                                   0x0,
                                   0x0,
                                   0x0,
                                   0x0,
                                   0x0,
                                   0xdb,
                                   0x7,
                                   0x3,
                                   0x19,
                                   0x16,
                                   0x29,
                                   0x19,
                                   0x0,
                                   0xdb,
                                   0x7,
                                   0x3,
                                   0x19,
                                   0x16,
                                   0x29,
                                   0x19,
                                   0x0,
                                   0xec,
                                   0xe7,
                                   0xe,
                                   0x0
                               }, 0, binEnd, 4, 28);
                //Requesting Bulba, either, any
                Array.Copy(pkm, 0x68, binEnd, 32, 16);
                //OT name
                Array.Copy(pkm, 0xe, binEnd, 48, 2);
                //OT ID
                Array.Copy(pkm, 0xc, binEnd, 50, 2);
                //SID
                Array.Copy(new byte[]
                               {
                                   0x1,
                                   0x14,
                                   0x2,
                                   0x8,
                                   0x1
                               }, 0, binEnd, 55, 5);
                Array.Resize(ref bin, 296);
                Array.Copy(binEnd, 0, bin, 236, 60);
            }
            return bin;
        }

        /// <summary>
        /// Prepares a Generation IV Pokemon for transmission
        /// </summary>
        /// <param name="currentDataFileName">The path to the Pokemon file</param>
        /// <returns>Byte Array</returns>
        /// <remarks></remarks>
        private byte[] GetBinHg(string currentDataFileName)
        {
            byte[] bin = null;
            if (File.Exists(currentDataFileName))
            {
                var pkm = File.ReadAllBytes(currentDataFileName);
                bin = DPPtHGSS.Pokemon.EncryptPokemon((byte[]) pkm.Clone());

                if (pkm.Length < 236)
                    Array.Resize(ref pkm, 236);
                else if (pkm.Length > 236)
                    return null;

                var binEnd = new byte[56];
                Array.Copy(pkm, 8, binEnd, 0, 2);
                //ID
                binEnd[2] = Convert.ToByte((pkm[64] & 4) > 0 ? 3 : (pkm[64] & 2) + 1);
                //Gender
                binEnd[3] = pkm[140];
                //Level
                Array.Copy(new byte[]
                               {
                                   0x1,
                                   0x0,
                                   0x3,
                                   0x0,
                                   0x0,
                                   0x0,
                                   0x0,
                                   0x0
                               }, 0, binEnd, 4, 8);
                //Requesting Bulba, either, any
                Array.Copy(pkm, 0x68, binEnd, 32, 16);
                //OT name
                Array.Copy(pkm, 0xc, binEnd, 48, 2);
                //OT ID
                Array.Resize(ref bin, 292);
                Array.Copy(binEnd, 0, bin, 236, 56);
            }
            return bin;
        }

        #endregion

        #region socket handling

        /// <summary>
        /// Continually reads data from the stream until all data has been read.
        /// </summary>
        /// <param name="socket">The socket to read data from.</param>
        /// <param name="recursive">If this parameter is true, this function is currently in a recursive loop.</param>
        /// <returns></returns>
        private IEnumerable<byte> GetData(ref Socket socket, bool recursive = false)
        {

            // Begin logging
            WriteLog(!recursive
                         ? "The socket has been queried for incoming data..."
                         : "Recursive call [GetData()]",
                     true);

            // create an initial buffer list to hold all the data
            var buffer = new List<byte>();

            // make sure the socket is still connected
            if (!socket.Connected)
                return buffer.ToArray();

            // okay, now create a big buffer.
            var bufferArray = new byte[socket.ReceiveBufferSize];

            // fill it
            var length = socket.Receive(bufferArray);

            // trim the data
            Array.Resize(ref bufferArray, length);

            // add it to the buffer
            buffer.AddRange(bufferArray);

            // check; allows us to keep receiving data.
            if (length.Equals(socket.ReceiveBufferSize) || socket.Available > 0)
                buffer.AddRange(GetData(ref socket));

            // All done
            WriteLog(!recursive
                         ? "The socket has completed its' request."
                         : "Recursive call finished [GetData()], backing up...",
                     true);

            // all done, give the buffer back now
            return buffer.ToArray();

        }

        /// <summary>
        /// Returns a full request structure.
        /// </summary>
        /// <param name="socket">The socket to process the request from.</param>
        /// <returns></returns>
        private Request GetRequest(ref Socket socket)
        {
            
            // grab our buffer data
            var bufferData = GetData(ref socket).ToArray();

            // we have all the data, convert.
            var stringData = _dsEncoding.GetString(bufferData);

            // create a new request structure
            var req = new Request(stringData);

            // that should parse, continue along and give back what we need.
            return req;

        }

        /// <summary>
        /// Sends a response back to the DS.
        /// </summary>
        /// <param name="socket">The socket to send the response to.</param>
        /// <param name="response">The response to send.</param>
        /// <returns></returns>
        private int SendResponse(ref Socket socket, Response response)
        {
            try
            {
                return socket.Send(_dsEncoding.GetBytes(response.ToString()));
            }
            catch (Exception)
            {
                return 0;
            }
        }

        #endregion

        #region general functions

        ///<summary>
        /// Base 64 Encoding with URL and Filename Safe Alphabet using UTF-8 character set.
        ///</summary>
        ///<param name="str">The origianl string</param>
        ///<returns>The Base64 encoded string</returns>
        public static string Base64Encode(string str)
        {
            var encbuff = Encoding.GetEncoding("iso-8859-1").GetBytes(str);
            return HttpServerUtility.UrlTokenEncode(encbuff);
        }

        ///<summary>
        /// Decode Base64 encoded string with URL and Filename Safe Alphabet using UTF-8.
        ///</summary>
        ///<param name="str">Base64 code</param>
        ///<returns>The decoded string.</returns>
        public static byte[] Base64Decode(string str)
        {
            var b = new Base64Decoder(str.ToCharArray());
            return b.GetDecoded();
        }

        /// <summary>
        /// Generates a random string of nonsense.
        /// </summary>
        /// <param name="length">The length of the string to generate.</param>
        /// <returns></returns>
        private string RandomString(int length)
        {
            return new string(
                Enumerable.Repeat("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789", length)
                          .Select(s => s[_rnd.Next(s.Length)])
                          .ToArray());
        }

        /// <summary>
        /// Get the SHA1 Hash of a String
        /// </summary>
        /// <param name="strToHash">The String to Hash</param>
        /// <returns></returns>
        /// <remarks></remarks>
        private string GetSHA1Hash(string strToHash)
        {
            var sha1Obj = new System.Security.Cryptography.SHA1CryptoServiceProvider();
            var bytesToHash = _dsEncoding.GetBytes(strToHash);

            bytesToHash = sha1Obj.ComputeHash(bytesToHash);

            return bytesToHash.Aggregate(string.Empty, (current, b) => current + b.ToString("x2"));
        }

        /// <summary>
        /// Returns the path to a pokemon file.
        /// </summary>
        /// <returns></returns>
        private string GetPokemon(Generation generation)
        {
            
            // There is a check outside this function, in Handler()
            // but let's be sure.
            if (DistributionMode == Operation.GenIV || DistributionMode == Operation.GenV || DistributionMode == Operation.Dual)
            {

                // are we folder or no?
                switch (DistributionOptions)
                {

                        #region individual

                    case OperationOptions.Individual: // not a folder.
                        return generation == Generation.IV ? GenIVFile : GenVFile;

                        #endregion

                        #region folder

                    case OperationOptions.Folder: // clearly a folder.
                        var genIV = !string.IsNullOrEmpty(GenIVGiveFolder)
                                        ? Directory.GetFiles(GenIVGiveFolder, "*.pkm")
                                        : new string[0];
                        var genV = !string.IsNullOrEmpty(GenVGiveFolder)
                                       ? Directory.GetFiles(GenVGiveFolder, "*.pkm")
                                       : new string[0];
                        switch (FolderOptions)
                        {
                                #region ordered

                            case FolderOptions.Ordered:

                                // we're gonna go in sequential order.
                                switch (generation)
                                {
                                    case Generation.IV:
                                        _gen4FolderCount++;
                                        if (_gen4FolderCount > genIV.Count() - 1)
                                            _gen4FolderCount = 0;
                                        return genIV[_gen4FolderCount];

                                    case Generation.V:
                                        _gen5FolderCount++;
                                        if (_gen5FolderCount > genV.Count() - 1)
                                            _gen5FolderCount = 0;
                                        return genV[_gen5FolderCount];
                                }

                                // something goofed somewhere...
                                return string.Empty;

                                #endregion

                                #region random

                            case FolderOptions.Random:

                                // We're gonna be randomized.
                                return generation == Generation.IV
                                           ? genIV[_rnd.Next(0, genIV.Count())]
                                           : genV[_rnd.Next(0, genV.Count())];

                                #endregion
                        }

                        break;

                        #endregion

                }

            }

            // something broke
            return string.Empty;

        }

        /// <summary>
        /// Builds tables for the system.
        /// </summary>
        /// <param name="generation">The generation to construct tables for.</param>
        /// <returns></returns>
        private string ConstructTable(Generation generation)
        {

            // define a new string builder function.
            var stringBld = new StringBuilder();

            // check for the proper modes: Giving only (of course).
            if((DistributionMode == Operation.GenIV || DistributionMode == Operation.GenV ||DistributionMode == Operation.Dual) && DistributionOptions == OperationOptions.Folder)
            {

                // header line
                stringBld.Append("<table>\n");

                // begin looping
                foreach (var file in Directory.GetFiles(generation == Generation.IV ? GenIVGiveFolder : GenVGiveFolder))
                {

                    // Append the table data.
                    stringBld.Append(
                        string.Format(string.IsNullOrEmpty(TableFormat)
                                          ? Properties.Resources.tableRow
                                          : TableFormat, Path.GetFileNameWithoutExtension(file)));
                }

                // add the finishing touches.
                stringBld.Append("</table>");

            }

            // Give it all back.
            return stringBld.ToString();

        }
        
/*
        /// <summary>
        /// Builds an HTML table of Pokemon.
        /// </summary>
        /// <param name="generation">The generation to build.</param>
        /// <returns></returns>
        private string BuildTable(Generation generation)
        {
            switch (generation)
            {
                case Generation.IV:

                    if (DistributionMode == Operation.GenIV || DistributionMode == Operation.Dual)
                    {
                        // check
                        return string.IsNullOrEmpty(GenIVGiveFolder)
                                   ? "The system is not in folder mode!"
                                   : Directory.GetFiles(GenIVGiveFolder).Aggregate("<table>\n",
                                                                                   (current, file) =>
                                                                                   current +
                                                                                   string.Format(
                                                                                       string.IsNullOrEmpty(TableFormat) ? Properties.Resources.tableRow : TableFormat +
                                                                                       "\n",
                                                                                       Path.
                                                                                           GetFileNameWithoutExtension
                                                                                           (file))) + "</table>";
                    }
                    return (DistributionMode == Operation.ReceiveIV || DistributionMode == Operation.ReceiveV ||
                            DistributionMode == Operation.ReceiveDual)
                               ? "The system is in receiving mode"
                               : "The system is running in Generation V mode only!";

                case Generation.V:
                    if (DistributionMode == Operation.GenV || DistributionMode == Operation.Dual)
                    {
                        // check
                        return string.IsNullOrEmpty(GenVGiveFolder)
                                   ? "The system is not in folder mode!"
                                   : Directory.GetFiles(GenVGiveFolder).Aggregate("<table>\n",
                                                                                  (current, file) =>
                                                                                  current +
                                                                                  string.Format(
                                                                                      string.IsNullOrEmpty(TableFormat) ? Properties.Resources.tableRow : TableFormat +
                                                                                      "\n",
                                                                                      Path.GetFileNameWithoutExtension
                                                                                          (file))) + "</table>";
                    }
                    return (DistributionMode == Operation.ReceiveIV || DistributionMode == Operation.ReceiveV ||
                            DistributionMode == Operation.ReceiveDual)
                               ? "The system is in receiving mode"
                               : "The system is running in Generation IV mode only!";

                default:
                    throw new ArgumentOutOfRangeException("generation");
            }
        }
*/

        /// <summary>
        /// Returns a string to display for individual Pokemon
        /// </summary>
        /// <param name="generation">The generation to use.</param>
        /// <returns></returns>
        private string BuildIndividual(Generation generation)
        {
            switch (generation)
            {
                case Generation.IV:

                    if(DistributionMode == Operation.Dual || DistributionMode == Operation.GenIV)
                    {
                        return string.IsNullOrEmpty(GenIVFile)
                                   ? "The Generation IV File is not properly configured!"
                                   : Path.GetFileNameWithoutExtension(GenIVFile);
                    }
                    if (DistributionMode == Operation.GenV)
                        return "The server is in Generation V mode only!";
                    return "The server is currently receiving Pokemon";

                case Generation.V:
                    if(DistributionMode == Operation.Dual || DistributionMode == Operation.GenV)
                    {
                        return string.IsNullOrEmpty(GenVFile)
                                   ? "The Generation V File is not properly configured!"
                                   : Path.GetFileNameWithoutExtension(GenVFile);
                    }
                    if (DistributionMode == Operation.GenIV)
                        return "The server is in Generation IV mode only!";
                    return "The server is currently receiving Pokemon";

                default:
                    throw new ArgumentOutOfRangeException("generation");
            }
        }

        #endregion

        #region generation IV specific functions

        /// <summary>
        /// Decrypts the pokemon file
        /// </summary>
        /// <param name="data">The Pokemon file</param>
        /// <returns></returns>
        /// <remarks></remarks>
        private IEnumerable<byte> HgDecryptData(ICollection<byte> data)
        {
            var keyData = new List<byte>(data);
            var obfKeyBlob = keyData.GetRange(0, 4);

            if (BitConverter.IsLittleEndian)
                obfKeyBlob.Reverse();

            var message = keyData.GetRange(4, data.Count - 4).ToArray();
            var obfKey = BitConverter.ToUInt32(obfKeyBlob.ToArray(), 0);
            var key = Convert.ToUInt32(obfKey ^ 0x4a3b2c1d);

            return HgStreamDecipher(message, new DPPtHGSS.GTS_PRNG(key));
        }

        /// <summary>
        /// Stream decipher thingamajig
        /// </summary>
        /// <param name="data">The data</param>
        /// <param name="keystream">The key</param>
        /// <returns></returns>
        /// <remarks></remarks>
        private IEnumerable<byte> HgStreamDecipher(IEnumerable<byte> data, DPPtHGSS.GTS_PRNG keystream)
        {
            return data.Select(c => Convert.ToByte((c ^ keystream.NextNum()) & 0xff)).ToList();
        }

        #endregion

        #region request handler

        private string BuildWelcomePage()
        {
            return
                CreatePage(string.IsNullOrEmpty(BrowserMessage)
                               ? Properties.Resources._default
                               : BrowserMessage.Replace("\n", "<br />"));
        }

        /// <summary>
        /// Generates the default information screen.
        /// </summary>
        /// <returns>String</returns>
        private string CreatePage(string msg)
        {

            // perform the replaces.
            return msg.Replace("$hg$", _gen4Count.ToString(CultureInfo.InvariantCulture))
                .Replace("$bw$", _gen5Count.ToString(CultureInfo.InvariantCulture))
                .Replace("$mode$", DistributionMode.ToString())
                .Replace("$stime$", DateTime.Now.ToShortTimeString())
                .Replace("$ltime$", DateTime.Now.ToLongTimeString())
                .Replace("$sdate$", DateTime.Now.ToShortDateString())
                .Replace("$ldate$", DateTime.Now.ToLongDateString())
                .Replace("$fgen4$", ConstructTable(Generation.IV))
                .Replace("$fgen5$", ConstructTable(Generation.V))
                .Replace("$cgen4$", BuildIndividual(Generation.IV))
                .Replace("$cgen5$", BuildIndividual(Generation.V));

        }

        /// <summary>
        /// Builds an unknown page display.
        /// </summary>
        /// <param name="requestStructure">A reference to the request structure.</param>
        /// <returns>String</returns>
        private string UnknownPageBuilder(ref Request requestStructure)
        {

            // Let's build a response.
            var strBld = new StringBuilder();

            // Build data!
            strBld.Append("<div align = \"center\">");
            strBld.AppendFormat("Requested Page: {0}<br />", requestStructure.PageFromRoot);
            strBld.AppendFormat("Passed Variables: {0}<br />", requestStructure.GetVars.Count);

            // Loop.
            foreach (var key in requestStructure.GetVars.Keys)
                strBld.AppendFormat("Key: {0}, Data: {1}<br />", key, requestStructure.GetVars[key]);

            // All done.
            strBld.Append("</div>");

            // Response.
            return strBld.ToString();

        }

        /// <summary>
        /// Builds a simple "I am online" page.
        /// </summary>
        /// <param name="ip">The IP address to insert into the page.</param>
        /// <returns>String</returns>
        private string CreateOnlinePage(string ip)
        {
            // Let's see if we can do something with an "online.asp" request.
            return ShowOnline ? String.Format("<div align = \"center\">Hello {0}, the server is online!</div>", ip) : string.Empty;
        }

        /// <summary>
        /// The routine that handles all incoming traffic.
        /// </summary>
        /// <param name="socket">The socket that has connected.</param>
        private void Handler(Socket socket)
        {
            
            // setup our variables
            string answerString = RandomString(32);
            var answer = new byte[0];
            var ip = socket.RemoteEndPoint.ToString().Split(':')[0];
            const string salt = "HZEdGCzcGGLvguqUEKQN";
            Request requestStructure;

            // try and retrieve a response
            try
            {
                requestStructure = GetRequest(ref socket);
            }
            catch (Exception e)
            {
             
                // log the exception
                WriteLog("An exception occured when trying to established a Request.", true);
                WriteLog(e.ToString(), true);
                return;

            }
            
            // Print some debug variables
            WriteLog("Request data retrieved, spilling contents:", true);
            WriteLog(string.Format("Page: {0}", requestStructure.PageFromRoot), true);
            WriteLog(string.Format("Action: {0}", requestStructure.Action), true);
            foreach (var key in requestStructure.GetVars.Keys)
            {
                WriteLog(string.Format("Key: {0}", key), true);
                WriteLog(string.Format("Data: {0}", requestStructure.GetVars[key]), true);
            }

            // begin processing the request.
            if (requestStructure.GetVars.Count == 0)
            {

                #region less than two variables

                //check for a potential online.asp call
                switch (requestStructure.Action)
                {
                    default:

                        SendResponse(ref socket, new Response(UnknownPageBuilder(ref requestStructure)));
                        break;

                    case "online":

                        // Send
                        SendResponse(ref socket, new Response(CreateOnlinePage(ip)));
                        break;

                    case "":

                        // send the message.
                        SendResponse(ref socket, new Response(BuildWelcomePage()));
                        break;

                }

                
                
                #endregion

            }
            else if (requestStructure.GetVars.Count < 2)
                answerString = RandomString(32);
            else
            {

                #region more than (or equal to) two variables

                switch (requestStructure.Action.Substring(1))
                {

                    

                    //default:

                    //    SendResponse(ref socket, new Response(UnknownPageBuilder(ref requestStructure)));
                    //    break;

                    case "info":

                        // someone entered.
                        WriteLog(string.Format("{0} has entered the {1} GTS.", ip, requestStructure.Generation));
                        answer = new byte[] {1, 0};

                        break;

                    case "setProfile":

                        // someone set profile?
                        WriteLog(string.Format("setProfile from {0}!", ip));
                        answer = new byte[] {0, 0, 0, 0, 0, 0, 0, 0};

                        break;

                    case "result":

                        #region Result

                        // Send a pokemon
                        WriteLog(string.Format("{0} is checking their status!", ip));

                        // let's make sure we're in the proper mode
                        if(DistributionMode == Operation.GenIV || DistributionMode == Operation.GenV || DistributionMode == Operation.Dual)
                        {

                            // Log
                            // WriteLog(string.Format("{0} will receive a Pokemon!", ip));

                            // okay, we can! yay!
                            var pkmPath = GetPokemon(requestStructure.Generation);
                            receiveCount++;
                            
                            WriteLog(string.Format("{0} - {1} will receive {2}!", ip, requestStructure.Generation, pkmPath.Remove(0, pkmPath.LastIndexOf("\\"))));

                            // now we need to sort the answer data.
                            answer = requestStructure.Generation == Generation.IV
                                         ? GetBinHg(pkmPath)
                                         : GetBin(pkmPath);

                        }
                        else
                            answer = new byte[] {5, 0}; // We are in receive mode.

                        break;

                        #endregion

                    case "get":

                        // get report
                        WriteLog(string.Format("Get from {0}!", ip));

                        break;

                    case "return":

                        // Log.
                        WriteLog(string.Format("Return from {0}!", ip));

                        break;

                    case "delete":

                        #region delete

                        // Log
                        WriteLog(string.Format("{0} has successfully received a Pokemon!", ip));
                        answer = new byte[] {1, 0};

                        // Increment
                        switch(requestStructure.Generation)
                        {
                            case Generation.IV:
                                _gen4Count++;
                                GtsPokemonSent(this, new GtsPokemonSentEventArgs {GameGeneration = requestStructure.Generation, NumberSent = _gen4Count});
                                break;

                            case Generation.V:
                                _gen5Count++;
                                GtsPokemonSent(this, new GtsPokemonSentEventArgs { GameGeneration = requestStructure.Generation, NumberSent = _gen5Count });
                                break;
                        }

                        break;

                        #endregion

                    case "post":

                        #region post

                        // pokemon is uploaded; simply reject it.
                        answer = new byte[] {0xc, 0};

                        // Uploading
                        WriteLog(string.Format("{0} is uploading a Pokemon!", ip));

                        // check to see if we're in the proper mode
                        if(DistributionMode == Operation.ReceiveIV || DistributionMode == Operation.ReceiveV || DistributionMode == Operation.ReceiveDual)
                        {

                            // generation check
                            switch (requestStructure.Generation)
                            {

                                case Generation.IV:

                                    // check to see if we can even receive
                                    if (DistributionMode == Operation.ReceiveIV || DistributionMode == Operation.ReceiveDual)
                                    {

                                        var b64Str = requestStructure.GetVars["data"].Replace('-', '+').Replace('_', '/');

                                        // Log
                                        WriteLog(string.Format("{0} is uploading a fourth generation Pokemon!", ip), true);

                                        // Grab our encrypted data.
                                        var encryptedBytes = Base64Decode(b64Str);

                                        // decrypt!
                                        var decryptedBytes = HgDecryptData(encryptedBytes).ToList();
                                        decryptedBytes = decryptedBytes.GetRange(4, decryptedBytes.Count - 4);

                                        // now grab other binary data
                                        var binData = decryptedBytes.GetRange(0, 236).ToArray();

                                        // we have all the pokemon data, yay.
                                        var pkmData = DPPtHGSS.Pokemon.DecryptPokemon(binData);

                                        // can just write all the bytes out.
                                        File.WriteAllBytes(Path.Combine(GenIVGetFolder, string.Format("{0} - " + DateTime.Now.ToString("yyyyMMddHHmmss", System.Globalization.CultureInfo.InvariantCulture) + ".pkm", ip)),
                                                           pkmData);

                                    }

                                    break;

                                case Generation.V:

                                    // Log
                                    WriteLog(string.Format("{0} is uploading a fifth generation Pokemon!", ip), true);

                                    // check to see if we can even receive
                                    if (DistributionMode == Operation.ReceiveV || DistributionMode == Operation.ReceiveDual)
                                    {

                                        var b64Str = requestStructure.GetVars["data"].Replace('-', '+').Replace('_', '/');

                                        // We can receive. Grab some data.
                                        var encryptedBytes = Base64Decode(b64Str);

                                        // grab the proper range
                                        var binaryData = encryptedBytes.ToList().GetRange(0xc, 220);

                                        // decyrpt it
                                        var decryptedBytes = BW.Pokemon.DecryptPokemon(binaryData.ToArray());

                                        // write it out.
                                        File.WriteAllBytes(Path.Combine(GenVGetFolder, string.Format("{0} - " + DateTime.Now.ToString("yyyyMMddHHmmss", System.Globalization.CultureInfo.InvariantCulture) + ".pkm", ip)),
                                                           decryptedBytes);

                                    }

                                    break;

                            }

                        }

                        break;

                        #endregion

                    case "post_finish":

                        // report the finish.
                        WriteLog(string.Format("Post-finish from {0}!", ip));
                        answer = new byte[] {1, 0};

                        break;

                    case "search":

                        // lol nope
                        WriteLog(string.Format("{0} requested a search, but we don't support searching.", ip));
                        answer = new byte[] {1, 0};

                        break;
                        
                }

                // build our answer string
                answerString = requestStructure.Generation == Generation.IV
                                   ? _dsEncoding.GetString(answer)
                                   : _dsEncoding.GetString(answer) +
                                     GetSHA1Hash(salt +
                                                 Convert.ToBase64String(answer).Replace('/', '_').Replace('+', '-') +
                                                 salt);

                #endregion

            }

            // All good, send the response
            var length = SendResponse(ref socket, new Response(answerString));
            WriteLog(string.Format("Sent {0} bytes of data to {1}!", length, ip), true);
            //socket.Shutdown(SocketShutdown.Both);
            //socket.Close();

        }

        #endregion

    }

    #endregion

}


/// <summary>
/// Summary description for Base64Decoder.
/// </summary>
public class Base64Decoder
{
    readonly char[] _source;
    readonly int _length;
    readonly int _length2;
    int _length3;
    readonly int _blockCount;
    readonly int _paddingCount;
    public Base64Decoder(char[] input)
    {
        int temp = 0;
        _source = input;
        _length = input.Length;

        //find how many padding are there
        for (int x = 0; x < 2; x++)
        {
            if (input[_length - x - 1] == '=')
                temp++;
        }
        _paddingCount = temp;
        //calculate the blockCount;
        //assuming all whitespace and carriage returns/newline were removed.
        _blockCount = _length / 4;
        _length2 = _blockCount * 3;
    }

    public byte[] GetDecoded()
    {
        var buffer = new byte[_length];//first conversion result
        var buffer2 = new byte[_length2];//decoded array with padding

        for (var x = 0; x < _length; x++)
        {
            buffer[x] = Char2Sixbit(_source[x]);
        }

        for (var x = 0; x < _blockCount; x++)
        {
            var temp1 = buffer[x * 4];
            var temp2 = buffer[x * 4 + 1];
            var temp3 = buffer[x * 4 + 2];
            var temp4 = buffer[x * 4 + 3];

            var b = (byte)(temp1 << 2);
            var b1 = (byte)((temp2 & 48) >> 4);
            b1 += b;

            b = (byte)((temp2 & 15) << 4);
            var b2 = (byte)((temp3 & 60) >> 2);
            b2 += b;

            b = (byte)((temp3 & 3) << 6);
            var b3 = temp4;
            b3 += b;

            buffer2[x * 3] = b1;
            buffer2[x * 3 + 1] = b2;
            buffer2[x * 3 + 2] = b3;
        }
        //remove paddings
        _length3 = _length2 - _paddingCount;
        var result = new byte[_length3];

        for (var x = 0; x < _length3; x++)
        {
            result[x] = buffer2[x];
        }

        return result;
    }

    private static byte Char2Sixbit(char c)
    {
        var lookupTable = new[]
					{	'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z',
						'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z',
						'0','1','2','3','4','5','6','7','8','9','+','/'};
        if (c == '=')
            return 0;
        for (var x = 0; x < 64; x++)
        {
            if (lookupTable[x] == c)
                return (byte)x;
        }
        //should not reach here
        return 0;
    }

}
