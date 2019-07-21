using System;
using System.IO;
using System.Windows.Forms;
using IniLibrary;
using Shiny2.Properties;
using gts;
//All self changes from original code marked with GANNIO, except for cosmetics to the forms and such cause I don't know how to comment those :\ they are listed below instead.
/*Cosmetic Changes from Shiny2:
Added Server IP for rerouting away from Nintendo's Server.
Altered DNS Settings page's description to describe above and slightly adjusted description box.
Added warning at bottom of run page for user to make sure they have a party of 6 (My first experiment resulted in Pokemon with unremovable seals, so I think this necessitates a warning). Hopefully someday someone can find a way to auto-add party details.
Added credits to top right of run page, as well as suggestion to use responsibly (Please do).
 */
namespace Shiny2
{
    public partial class FrmConfiguration
    {

        /// <summary>
        /// The DNS server.
        /// </summary>
        readonly Dns _dns = new Dns();

        /// <summary>
        /// The GTS server.
        /// </summary>
        readonly Gts _gts = new Gts();


        private StreamWriter _dnsStream;
        private StreamWriter _gtsStream;


        /// <summary>
        /// Returns the external IP address.
        /// </summary>
        /// <returns></returns>
        private static string GetIP()
        {
            return new System.Net.WebClient().DownloadString(Settings.Default.externalIp);
        }

/*
        /// <summary>
        /// Converts an Image to a Base64 string.
        /// </summary>
        /// <param name="image">The image to use.</param>
        /// <param name="format">The format to save the image in</param>
        /// <returns></returns>
        private static string ImageToBase64(Image image, System.Drawing.Imaging.ImageFormat format = null)
        {
            // check
            if (format == null)
                format = System.Drawing.Imaging.ImageFormat.Png;

            using (var ms = new MemoryStream())
            {
                // Convert Image to byte[]
                image.Save(ms, format);
                byte[] imageBytes = ms.ToArray();

                // Convert byte[] to Base64 String
                string base64String = Convert.ToBase64String(imageBytes);
                return base64String;
            }
        }
*/

        /// <summary>
        /// Writes settings to an INI file.
        /// </summary>
        private void SaveSettings()
        {

            var ini = new INI();

            // start with gts information.
            ini.Add("gts");

            ini.Add("gts", "gtsmode", cbOperations.SelectedIndex);
            ini.Add("gts", "game", cbGeneration.SelectedIndex);
            ini.Add("gts", "dmode", cbDistribution.SelectedIndex);
            ini.Add("gts", "random", cbRandomized.Checked);

            ini.Add("gts", "IV-Dis", tbGenIVSend.Text);
            ini.Add("gts", "V-Dis", tbGenVSend.Text);

            ini.Add("gts", "IV-Get", tbGenIVReceive.Text);
            ini.Add("gts", "V-Get", tbGenVReceive.Text);

            // now onto the DNS
            ini.Add("dns");
            ini.Add("dns", "ip", tbIP.Text);
            //GANNIO: Modifications: Added Alt Server DNS saving.
            ini.Add("dns", "AltIP", tBAltWFCIP.Text);
            // finally, miscellaneous items.
            ini.Add("misc");
            ini.Add("misc", "logFile", cbLog.Checked);
            ini.Add("misc", "jargon", cbJargon.Checked);
            ini.Add("misc", "bowser", "msg.txt");
            ini.Add("misc", "tables", "tbl.txt");
            ini.Add("misc", "custom", cbCustomMsg.Checked);
            ini.Add("misc", "template", cbTemplates.SelectedItem.ToString());
            ini.Add("misc", "showonline", cbOnline.Checked);

            // write out the browser information
            rtbBrowser.SaveFile("msg.txt", RichTextBoxStreamType.UnicodePlainText);
            rtbTable.SaveFile("tbl.txt", RichTextBoxStreamType.UnicodePlainText);

            // save ini
            ini.Save("settings.ini", INI.Type.INI);

            // display
            // MessageBox.Show(Resources.Saved, Resources.Saved, MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        /// <summary>
        /// Attaches the GTS handler to the object.
        /// </summary>
        private void Attach()
        {
            // gts too
            _gts.GtsLog +=
                (sender, args) =>
                lbGtsLog.Invoke(
                    new Action(
                        () =>
                            {
                                var line = string.Format("{0}: {1}", DateTime.Now.ToShortTimeString(), args.Data);
                                lbGtsLog.Items.Add(line);
                                lbGtsLog.SelectedIndex = lbGtsLog.Items.Count - 1;
                                if(lbGtsLog.Items.Count > 60)
                                    lbGtsLog.Items.RemoveAt(0);
                                if (!cbLog.Checked) return;
                                _gtsStream.WriteLine(line);
                                _gtsStream.Flush();
                            }
                        ));

            _gts.GtsPokemonSent += (sender, args) =>
                                   Invoke(
                                       new Action(() =>
                                                      {
                                                          switch(args.GameGeneration)
                                                          {
                                                              case Generation.IV:
                                                                  tbGenIVStatistics.Text =
                                                                      string.Format("Gen IV Pokemon: {0}",
                                                                                    args.NumberSent);
                                                                  break;

                                                              case Generation.V:
                                                                  tbGenVStatistics.Text =
                                                                      string.Format("Gen V Pokemon: {0}",
                                                                                    args.NumberSent);
                                                                  break;
                                                              
                                                          }
                                                      }));
            _gts.GtsPokemonReceived += (sender, args) =>
                       Invoke(
                           new Action(() =>
                           {
                              /* switch (args.GameGeneration)
                               {
                                   case Generation.IV:*/
                                       tBReceivedStatistics.Text =
                                           string.Format("Received: {0}",
                                                         args.NumberSent);
                               /*        break;

                                   case Generation.V:
                                       tbGenVStatistics.Text =
                                           string.Format("Gen V Pokemon: {0}",
                                                         args.NumberSent);
                                       break;

                               }*/
                           }));

            _dns.DnsLog +=
                (sender, args) =>
                lbDnsLog.Invoke(
                    new Action(
                        () =>
                        {
                            var line = string.Format("{0}: {1}", DateTime.Now.ToShortTimeString(), args.Data);
                            lbDnsLog.Items.Add(line);
                            lbDnsLog.SelectedIndex = lbDnsLog.Items.Count - 1;
                            if (lbDnsLog.Items.Count > 60)
                                lbDnsLog.Items.RemoveAt(0);
                            if (!cbLog.Checked) return;
                            _dnsStream.WriteLine(line);
                            _dnsStream.Flush();
                        }
                        ));

        }

        public FrmConfiguration()
        {
            InitializeComponent();
            Icon = Resources.jirachi_128;
            Attach();
        }
        

        private void FrmConfigurationLoad(object sender, EventArgs e)
        {
            // tbIP.Text = GetIP();

            cbDistribution.SelectedIndex = 0;
            cbGeneration.SelectedIndex = 0;
            cbOperations.SelectedIndex = 0;
            cbTemplates.SelectedIndex = 0;

            // Laod the INI
            if(File.Exists("settings.ini"))
            {
                var ini = new INI();
                ini.Load("settings.ini", INI.Type.INI);

                // process
                cbOperations.SelectedIndex = ini.GetKeyValue("gts", "gtsmode", 0);
                cbGeneration.SelectedIndex = ini.GetKeyValue("gts", "game", 0);
                cbDistribution.SelectedIndex = ini.GetKeyValue("gts", "dmode", 0);
                cbRandomized.Checked = ini.GetKeyValue("gts", "random", false);

                tbGenIVSend.Text = ini.GetKeyValue("gts", "IV-Dis", string.Empty);
                tbGenVSend.Text = ini.GetKeyValue("gts", "V-Dis", string.Empty);

                tbGenIVReceive.Text = ini.GetKeyValue("gts", "IV-Get", string.Empty);
                tbGenVReceive.Text = ini.GetKeyValue("gts", "V-Get", string.Empty);

                tbIP.Text = ini.GetKeyValue("dns", "ip", string.Empty);
                //GANNIO: Changes: Add loading of Alt server DNS file.
                tBAltWFCIP.Text = ini.GetKeyValue("dns", "AltIP", string.Empty);
                cbLog.Checked = ini.GetKeyValue("misc", "logFile", false);
                cbJargon.Checked = ini.GetKeyValue("misc", "jargon", false);
                
                rtbBrowser.LoadFile(ini.GetKeyValue("misc", "bowser", "msg.txt"), RichTextBoxStreamType.UnicodePlainText);

                try
                {
                    rtbTable.LoadFile(ini.GetKeyValue("misc", "tables", "tbl.txt"));
                }
                catch (Exception)
                { }

                cbCustomMsg.Checked = ini.GetKeyValue("misc", "custom", false);
                cbTemplates.SelectedItem = ini.GetKeyValue("misc", "template", "Default");
                cbOnline.Checked = ini.GetKeyValue("misc", "showonline", false);

            }

            // Check for logging reqests
            if(cbLog.Checked)
            {
                try
                {
                    _dnsStream = new StreamWriter("dns_log.txt", true);
                    _gtsStream = new StreamWriter("gts_log.txt", true);
                }
                catch (Exception)
                { }
            }
            _dns.altWFCIP = tBAltWFCIP.Text;//GANNIO: Setup alternate server DNS if not set up already.
        }

        private void BtnDetectClick(object sender, EventArgs e)
        {
            tbIP.Text = GetIP();
        }

        private void CbOperationsSelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbOperations.SelectedIndex)
            {
                case 0: // Distribute
                    gbDistribute.Enabled = true;
                    gbReceive.Enabled = false;
                    break;

                case 1: // Receive
                    gbDistribute.Enabled = false;
                    gbReceive.Enabled = true;
                    break;
                default: // People broke it :(
                    gbDistribute.Enabled = false;
                    gbReceive.Enabled = false;
                    break;
            }
        }

        private void CbGenerationSelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbGeneration.SelectedIndex)
            {
                case 0: // Gen IV
                    tbGenIVReceive.Enabled = true;
                    tbGenIVSend.Enabled = true;
                    btnGenIV.Enabled = true;
                    btnGenIVGet.Enabled = true;

                    tbGenVReceive.Enabled = false;
                    tbGenVSend.Enabled = false;
                    btnGenV.Enabled = false;
                    btnGenVGet.Enabled = false;
                    break;

                case 1: // Gen V
                    tbGenIVReceive.Enabled = false;
                    tbGenIVSend.Enabled = false;
                    btnGenIV.Enabled = false;
                    btnGenIVGet.Enabled = false;

                    tbGenVReceive.Enabled = true;
                    tbGenVSend.Enabled = true;
                    btnGenV.Enabled = true;
                    btnGenVGet.Enabled = true;
                    break;

                case 2: // All
                    tbGenIVReceive.Enabled = true;
                    tbGenIVSend.Enabled = true;
                    btnGenIV.Enabled = true;
                    btnGenIVGet.Enabled = true;

                    tbGenVReceive.Enabled = true;
                    tbGenVSend.Enabled = true;
                    btnGenV.Enabled = true;
                    btnGenVGet.Enabled = true;
                    break;

            }
        }

        private void CbDistributionSelectedIndexChanged(object sender, EventArgs e)
        {

            tbGenIVReceive.Clear();
            tbGenVReceive.Clear();

            switch (cbDistribution.SelectedIndex)
            {
                case 0:
                    cbRandomized.Enabled = false;
                    cbRandomized.Checked = false;
                    break;

                case 1:
                    cbRandomized.Enabled = true;
                    break;

            }
        }

        private void BtnGenIVClick(object sender, EventArgs e)
        {
            switch (cbDistribution.SelectedIndex)
            {
                case 0: // individual
                    using (var ofd = new OpenFileDialog { Filter = Resources.PkmFilter, Title = Resources.SelectPkm })
                        if (ofd.ShowDialog().Equals(DialogResult.OK))
                            tbGenIVSend.Text = ofd.FileName;
                    break;
                case 1: // folder
                    using (var fbd = new FolderBrowserDialog { Description = Resources.FolderDistribute })
                        if (fbd.ShowDialog(this).Equals(DialogResult.OK))
                            tbGenIVSend.Text = fbd.SelectedPath;
                    break;
            }
        }

        private void BtnGenVClick(object sender, EventArgs e)
        {
            switch (cbDistribution.SelectedIndex)
            {
                case 0: // individual
                    using (var ofd = new OpenFileDialog { Filter = Resources.PkmFilter, Title = Resources.SelectPkm })
                        if (ofd.ShowDialog().Equals(DialogResult.OK))
                            tbGenVSend.Text = ofd.FileName;
                    break;
                case 1: // folder
                    using (var fbd = new FolderBrowserDialog { Description = Resources.FolderDistribute })
                        if (fbd.ShowDialog(this).Equals(DialogResult.OK))
                            tbGenVSend.Text = fbd.SelectedPath;
                    break;
            }
        }

        private void BtnGenIVGetClick(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog { Description = Resources.FolderSave })
                if (fbd.ShowDialog(this).Equals(DialogResult.OK))
                    tbGenIVReceive.Text = fbd.SelectedPath;
        }

        private void BtnGenVGetClick(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog { Description = Resources.FolderSave })
                if (fbd.ShowDialog(this).Equals(DialogResult.OK))
                    tbGenVReceive.Text = fbd.SelectedPath;
        }

        private void BtnStartDnsClick(object sender, EventArgs e)
        {
            if(btnStartDNS.Text.Contains("Initialize"))
            {
                // Set the IP
                _dns.IP = tbIP.Text;

                // start
                _dns.Start(tBAltWFCIP.Text);
    
                // change
                btnStartDNS.Text = Resources.StopDns;

            }
            else
            {
                _dns.Stop();
                btnStartDNS.Text = Resources.StartDns;
            }

        }

        private void BtnStartGtsClick(object sender, EventArgs e)
        {
            if(btnStartGTS.Text.Contains("Ini&t"))
            {

                #region distribution
                // Let's see if we're distributing.
                if(cbOperations.SelectedIndex.Equals(0))
                {
                    // we are distributing.

                    // set randomized
                    _gts.FolderOptions = (cbRandomized.Enabled && cbRandomized.Checked)
                                       ? FolderOptions.Random
                                       : FolderOptions.Ordered;

                    // figure out the mode
                    _gts.DistributionOptions = (OperationOptions) cbDistribution.SelectedIndex;

                    // time to figure out the distribution mode.
                    switch (cbGeneration.SelectedIndex)
                    {
                        case 0: _gts.DistributionMode = Operation.GenIV;

                            if (_gts.DistributionOptions == OperationOptions.Individual)
                                _gts.GenIVFile = tbGenIVSend.Text;
                            else
                                _gts.GenIVGiveFolder = tbGenIVSend.Text;

                            break;

                        case 1: _gts.DistributionMode = Operation.GenV;

                            if (_gts.DistributionOptions == OperationOptions.Individual)
                                _gts.GenVFile = tbGenVSend.Text;
                            else
                                _gts.GenVGiveFolder = tbGenVSend.Text;

                            break;

                        case 2: _gts.DistributionMode = Operation.Dual;

                            if (_gts.DistributionOptions == OperationOptions.Individual)
                            {
                                _gts.GenIVFile = tbGenIVSend.Text;
                                _gts.GenVFile = tbGenVSend.Text;
                            }
                            else
                            {
                                _gts.GenIVGiveFolder = tbGenIVSend.Text;
                                _gts.GenVGiveFolder = tbGenVSend.Text;
                            }

                            break;
                    }



                }
                #endregion

                #region receiving

                if(cbOperations.SelectedIndex.Equals(1))
                {
                    // we are receiving.
                    switch(cbGeneration.SelectedIndex)
                    {
                        case 0: // gen 4
                            _gts.DistributionMode = Operation.ReceiveIV;
                            _gts.GenIVGetFolder = tbGenIVReceive.Text;
                            break;
                        case 1: // gen 5
                            _gts.DistributionMode = Operation.ReceiveV;
                            _gts.GenVGetFolder = tbGenVReceive.Text;
                            break;
                        case 2: // all
                            _gts.DistributionMode = Operation.ReceiveDual;
                            _gts.GenIVGetFolder = tbGenIVReceive.Text;
                            _gts.GenVGetFolder = tbGenVReceive.Text;
                            break;
                    }

                }

                #endregion

                #region extra config

                _gts.DumpExtra = cbJargon.Checked;
                _gts.BrowserMessage = rtbBrowser.Text;
                _gts.ShowOnline = cbOnline.Checked;

                #endregion

                btnStartGTS.Text = Resources.GtsStop;

                _gts.Start();

            }
            else
            {
                _gts.Stop();
                btnStartGTS.Text = Resources.GtsStart;
            }
        }

        private void LbDnsLogDoubleClick(object sender, EventArgs e)
        {
            if (lbDnsLog.SelectedIndex >= 0)
                MessageBox.Show(lbDnsLog.SelectedItem.ToString(), Resources.DnsLog, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void LbGtsLogDoubleClick(object sender, EventArgs e)
        {
            if (lbGtsLog.SelectedIndex >= 0)
                MessageBox.Show(lbGtsLog.SelectedItem.ToString(), Resources.GtsLog, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void FrmConfigurationFormClosing(object sender, FormClosingEventArgs e)
        {
            if(btnStartGTS.Text.Contains("Stop")) _gts.Stop();
            if(btnStartDNS.Text.Contains("Stop")) _dns.Stop();

            if(cbLog.Checked)
            {
                _gtsStream.Flush();
                _dnsStream.Flush();

                _gtsStream.Close();
                _dnsStream.Close();
            }
            SaveSettings();
        }

        /*
            private void BtnHintsClick(object sender, EventArgs e)
            {
                MessageBox.Show(Resources.special_codes, Resources.Hints, MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
        */

        private void LinkLabel1LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            lbDnsLog.Items.Clear();
        }

        private void LinkLabel2LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            lbGtsLog.Items.Clear();
        }

        private void BtnGtsSaveClick(object sender, EventArgs e)
        {
            SaveSettings();
        }

        private void BtnDnsSaveClick(object sender, EventArgs e)
        {
            SaveSettings();
        }

        private void CbLogCheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbLog.Checked)
                {
                    _dnsStream = new StreamWriter("dns_log.txt", true);
                    _gtsStream = new StreamWriter("gts_log.txt", true);
                }
                else
                {
                    _dnsStream.Flush();
                    _gtsStream.Flush();
                    _dnsStream.Close();
                    _gtsStream.Close();
                }
            }
            catch (Exception)
            { }
        }

        /*
            private void BtnApplyBrowserClick(object sender, EventArgs e)
            {
                _gts.BrowserMessage = rtbBrowser.Text;
            }
        */

        private void CbCustomMsgCheckedChanged(object sender, EventArgs e)
        {
            // rtbBrowser.Enabled = cbCustomMsg.Checked;
            groupBox1.Enabled = cbCustomMsg.Checked;
            groupBox2.Enabled = cbCustomMsg.Checked;
        }

        private void BtnApplyClick(object sender, EventArgs e)
        {

            // Check for a custom message option.
            if (cbCustomMsg.Checked)
            {

                // set the messages to our content.
                _gts.BrowserMessage = rtbBrowser.Text;
                _gts.TableFormat = rtbTable.Text;

            }
            else
            {

                // Template loading.
                switch (cbTemplates.SelectedIndex)
                {
                    case 0:

                        // Default built in template.
                        _gts.BrowserMessage = string.Empty;
                        _gts.TableFormat = string.Empty;
                        break;

                    default:

                        // different template altogether, awesome.
                        var path = Path.Combine(Application.StartupPath, "Templates",
                                                cbTemplates.SelectedItem.ToString());



                        break;

                }    
            }
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            notifyIcon1.Visible = false;
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void FrmConfiguration_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState)
            {
                notifyIcon1.Visible = true;
                this.Hide();
            }
            else if (FormWindowState.Normal == this.WindowState)
            {
                notifyIcon1.Visible = false;
            }
        }

        private void tBAltWFCIP_TextChanged(object sender, EventArgs e)
        {
            _dns.altWFCIP = tBAltWFCIP.Text;
        }

        private void tbGenIVStatistics_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void rtbDirections_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }
    }
}
