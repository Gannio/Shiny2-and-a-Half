using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Linq;

namespace gts
{

    public class DnsLogDataEventArgs : EventArgs
    {
        /// <summary>
        /// The data to log.
        /// </summary>
        public string Data { get; set; }
    }

    public class DnsExceptionDataEventArgs : EventArgs
    {

        /// <summary>
        /// A custom error message.
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// The raw exception.
        /// </summary>
        public Exception Exception { get; set; }

    }

    public class Dns
    {
        public string altWFCIP = "208.67.222.222";
        //GANNIO: In the original Shiny2, this was an openDNS used by the program. Now that we redirect the signal to the alt server itself, we made this variable public so we can set by UI later. Actual DNS left here as a placeholder, gets overwritten.

        #region variables

        private Socket _dnsServer;
        private Socket _altServer;
        private Thread _readThread;

        #endregion

        #region properties

        /// <summary>
        /// The ip address to spoof.
        /// </summary>
        public string IP { get; set; }

        /// <summary>
        /// The IP address of Nintendo's DNS/GTS server.
        /// </summary>
        public string OpenDNS { get { return altWFCIP; } }
        
        #endregion

        #region events

        public event DnsLoggingData DnsLog = delegate { };
        public event DnsShutdown Shutdown = delegate { };
        public event DnsException Exception = delegate { };

        public delegate void DnsShutdown(object sender, EventArgs e);
        public delegate void DnsLoggingData(object sender, DnsLogDataEventArgs e);
        public delegate void DnsException(object sender, DnsExceptionDataEventArgs e);

        /// <summary>
        /// Writes data to the log quickly.
        /// </summary>
        /// <param name="data">The data to write.</param>
        private void WriteLog(string data)
        {
            DnsLog(this, new DnsLogDataEventArgs { Data = data });
        }

        #endregion

        #region routines

        /// <summary>
        /// Start the DNS system.
        /// </summary>
        public void Start(string altWFCIP)//GANNIO: Added a parameter to start for rerouting the Main Wifi's DNS to alternate servers.
        {

            // check
            //if(!isDottedIPv4(IP))
            //    WriteLog(string.Format("{0} is not a valid IP!", IP));
            //else
            {
                WriteLog("*** RoC's Fake DNS server v0.7 ***");
                WriteLog("*** Based on ShinyJirachi's Fake DNS server v0.6 ***");
                WriteLog("*** Based on Fake DNS server v0.5 by RoC ***");
                WriteLog("*** Based on ShinyJirachi Fake DNS server v0.4 ***");
                WriteLog("*** Based on M@T's Fake DNS server v0.3 ***");
                WriteLog("*** Based on LordLandon's sendpkm.py ***");
                WriteLog("*** AltWFC modifications by Gannio ***");
                try
                {
                    _dnsServer = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                    _altServer = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                    _dnsServer.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, 1);
                    _dnsServer.Bind(new IPEndPoint(IPAddress.Any, 53));
                    _readThread = new Thread(Spoof);
                    _readThread.Start();
                }
                catch (Exception exception)
                {
                    // Problem
                    Exception(this,
                        new DnsExceptionDataEventArgs
                            {
                                ErrorMessage = "There was a problem initializing the DNS system.",
                                Exception = exception
                            });
                }
            }
        }

        /// <summary>
        /// Stop the DNS system.
        /// </summary>
        public void Stop()
        {
            _dnsServer.Close();
            _readThread.Abort();
        }

        /// <summary>
        /// The infinite spoofing loop.
        /// </summary>
        private void Spoof()
        {

            // Setup some variables.
            const char character = (char)0;
            var leave = false;
            var ipBytes = new byte[4];
            var ipAddr = IP.Split('.');
            var allowedHosts = new[]
                                        {
                                            "conntest.nintendowifi.net", "syachi2ds.available.nintendowifi.net",
                                            "gamestats2.gs.nintendowifi.net", "nas.nintendowifi.net", "gpcm.gs.nintendowifi.net",
                                            "pkvldtprod.nintendo.co.jp", "syachi2ds.available.gs.nintendowifi.net"
                                        };

            // Spoofer bytes.
            for (var i = 0; i < 4; i++)
                ipBytes[i] = Convert.ToByte(ipAddr[i]);

            // create our encoding type.
            var encoding = Encoding.GetEncoding("iso-8859-1");
            // var encoding = Encoding.UTF8;

            // infinite loop
            while (!leave)
            {
                try
                {
                    // We're gonna need these to be constantly reinitialized.
                    var rawHost = string.Empty;
                    var epInitialize = new IPEndPoint(IPAddress.Any, 0);
                    var anyEndPoint = (EndPoint)epInitialize;

                    // reinitialize our request array
                    var clientRequest = new byte[_dnsServer.ReceiveBufferSize];

                    // grab the client requests
                    var receiveLength = _dnsServer.ReceiveFrom(clientRequest, SocketFlags.None,
                                                               ref anyEndPoint);

                    // reize
                    Array.Resize(ref clientRequest, receiveLength);

                    // encoding time.
                    var requestString = encoding.GetString(clientRequest);
                    var host = requestString.Substring(12, requestString.IndexOf(character, 12) - 12);

                    var n = 0;
                    while (n < host.Length)
                    {
                        rawHost += host.Substring(n + 1, clientRequest[n + 12]) + ".";
                        n += clientRequest[n + 12] + 1;
                    }
                    rawHost = rawHost.Trim('.').Trim();

                    // log quickly
                    // WriteLog(string.Format("Incoming data from {0}!", ((IPEndPoint) anyEndPoint).Address));

                    WriteLog(string.Format("{0} has requested {1}!", ((IPEndPoint)anyEndPoint).Address, rawHost));

                    // Check to see if this person is legitimate.

                    if (allowedHosts.Contains(rawHost.Trim()))
                    {
                        WriteLog("This is a valid request.");

                        // Okay, legitimate. Let's keep going

                        // Get nintendo's response.
                        var altServerReply = new byte[_altServer.ReceiveBufferSize];

                        // GANNIO: Changed, create the connection to the Alternate WFC server for verification process.
                        _altServer = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp) { ReceiveTimeout = 2000, SendTimeout = 2000 };
                        _altServer.Connect(OpenDNS, 53);
                        _altServer.Send(clientRequest, clientRequest.Length, SocketFlags.None);

                        // reply
                        var altServerReceiveLength = _altServer.Receive(altServerReply, SocketFlags.None);

                        // resize
                        Array.Resize(ref altServerReply, altServerReceiveLength);

                        // check
                        if (rawHost == "gamestats2.gs.nintendowifi.net")
                            Array.Copy(ipBytes, 0, altServerReply, 0x3c, 4);

                        // get the client reply ready
                        // var clientReply = encoding.GetString(nintendoReply);

                        // log
                        // WriteLog(string.Format("Sending reply to {0}!", ((IPEndPoint) anyEndPoint).Address));

                        // send it off
                        _dnsServer.SendTo(altServerReply, anyEndPoint);
                    }
                    else
                    {
                        WriteLog("Invalid Request! " + rawHost.Trim());
                    }
                }
                catch (ThreadAbortException)
                {
                    // leave...
                    WriteLog("The DNS system has received a shutdown request.");
                    leave = true;
                    _dnsServer.Close();
                    _dnsServer.Dispose();
                    Shutdown(this, new EventArgs());
                }
                catch (Exception e)
                {
                    Exception(this, new DnsExceptionDataEventArgs { ErrorMessage = "Shiny2 has run into a problem", Exception = e });
                }
            }
        }

        #endregion

    }

}
