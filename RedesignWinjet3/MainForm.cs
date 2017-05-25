using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RedesignWinjet3
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            // Resize form
            this.Size = new Size(800, 600);

        }

        private void OnFrameChanged(object o, EventArgs e)
        {
            this.Invalidate();
        }

        public void RemoveArrowsTabless(object sender, EventArgs e)
        {
            // Make sure to disable the arrows on the right top of the tab control
            // Use this if you have more tabs than the current width
            this.tablessControl2.ItemSize = new System.Drawing.Size(tablessControl2.Width, tablessControl2.Height);
        }
        // ALARMS
        private void button4_Click(object sender, EventArgs e)
        {
            mainTablessControl.SelectedIndex = 1;
            tablessControl2.SelectedIndex = 2;

            if (btAlarm.Image != Properties.Resources.icon_03)
                btAlarm.Image = Properties.Resources.icon_03;
        }
        // OVERVIEW
        private void button1_Click(object sender, EventArgs e)
        {
            mainTablessControl.SelectedIndex = 0;
            tablessControl2.SelectedIndex = 0;

            if (btHome.Image != Properties.Resources.icon_01)
                btHome.Image = Properties.Resources.icon_01;
        }
        /// <summary>
        /// Button Closes application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }
        private void timerClock_Tick(object sender, EventArgs e)
        {
            lbRealTime.Text = DateTime.Now.ToString("T");

            // fix strange behaviors on Win7
            //is this related to https://support.microsoft.com/en-us/kb/2587473/en-us 
            if (this.TopMost)
               this.TopMost = false;


            // Animate image

        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            this.lbRealTime.Text = DateTime.Now.ToString("T");
        }
        // PRINTHEAD
        private void button5_Click(object sender, EventArgs e)
        {
            mainTablessControl.SelectedIndex = 2;

            if (btPrinthead.Image != Properties.Resources.icon_09)
                btPrinthead.Image = Properties.Resources.icon_09;
        }
        // SKI
        private void button6_Click(object sender, EventArgs e)
        {
            mainTablessControl.SelectedIndex = 3;

            if (btSki.Image != Properties.Resources.icon_11)
                btSki.Image = Properties.Resources.icon_11;
        }
        // CAP AND WIPE
        private void button7_Click(object sender, EventArgs e)
        {
            mainTablessControl.SelectedIndex = 4;

            if (btCapWipe.Image != Properties.Resources.icon_13)
                btCapWipe.Image = Properties.Resources.icon_13;
        }
        // DIAGNOSTIC
        private void button8_Click(object sender, EventArgs e)
        {
            mainTablessControl.SelectedIndex = 5;

            if (btDiagnostic.Image != Properties.Resources.icon_15)
                btDiagnostic.Image = Properties.Resources.icon_15;
        }
        // SETTINGS
        private void button3_Click(object sender, EventArgs e)
        {
            mainTablessControl.SelectedIndex = 7;
            tablessControl2.SelectedIndex = 1;

            if (btSettings.Image != Properties.Resources.icon_05)
                btSettings.Image = Properties.Resources.icon_05;

            ListViewItem lvi = new ListViewItem("Printer Delay 1");
            lvi.SubItems.Add("15");
            listView3.Items.Add(lvi);
            ListViewItem lvi2 = new ListViewItem("Camera Delay 1");
            lvi2.SubItems.Add("31");
            listView3.Items.Add(lvi2);

            listView3.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

        }

        private void button10_Click(object sender, EventArgs e)
        {
            mainTablessControl.SelectedIndex = 6;
            button10.Image = Properties.Resources.icon_17;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            CultureInfo ci = new CultureInfo("en-US");
            // Change the language to English
            Assembly a = Assembly.Load("RedesignWinjet3");
            ResourceManager rm = new ResourceManager("RedesignWinjet3.Lang.langres", a);

            ChangeLanguage(ci,rm);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            CultureInfo ci = new CultureInfo("pt-PT");
            // Change the language to English
            Assembly a = Assembly.Load("RedesignWinjet3");
            ResourceManager rm = new ResourceManager("RedesignWinjet3.Lang.langres", a);

            ChangeLanguage(ci, rm);
        }

        #region Events 

        public void Leave_AdjuScreen(object sender, EventArgs e)
        {
            button10.Image = Properties.Resources.icon_18;
        }
        public void Leave_RestAccess(object sender, EventArgs e)
        {
            button2.Image = Properties.Resources.icon_20;
        }
        public void Leave_OverviewTab(object sender, EventArgs e)
        {
            btHome.Image = Properties.Resources.icon_02;
        }
        public void Leave_SettingsTab(object sender, EventArgs e)
        {   
            btSettings.Image = Properties.Resources.icon_06;
        }
        public void Leave_AlarmsTab(object sender, EventArgs e)
        {
            btAlarm.Image = Properties.Resources.icon_04;
        }
        public void Leave_SkiTab(object sender, EventArgs e)
        {
            btSki.Image = Properties.Resources.icon_12;
        }
        public void Leave_phTab(object sender, EventArgs e)
        {
            btPrinthead.Image = Properties.Resources.icon_10;
        }
        public void Leave_diagnosticTab(object sender, EventArgs e)
        {
            btDiagnostic.Image = Properties.Resources.icon_16;
        }
        public void Leave_capWipeTab(object sender, EventArgs e)
        {
            btCapWipe.Image = Properties.Resources.icon_14;
        }
        #endregion

        private void button2_Click_1(object sender, EventArgs e)
        {
            mainTablessControl.SelectedIndex = 8;
            button2.Image = Properties.Resources.icon_19;
        }

        private void button7_Click_1(object sender, EventArgs e)
        {

        }

        public void ChangeLanguage(CultureInfo ci, ResourceManager rm)
        {
            adjmLabel.Text = rm.GetString("adjmLabel", ci);
            btEng.Text = rm.GetString("btEnglish", ci);
            btSpan.Text = rm.GetString("btSpanish", ci);
            btPort.Text = rm.GetString("btPortuguese", ci);
            btFrenc.Text = rm.GetString("btFrench", ci);
        }

        private void btSpan_Click(object sender, EventArgs e)
        {
            CultureInfo ci = new CultureInfo("es-ES");
            Assembly a = Assembly.Load("RedesignWinjet3");
            ResourceManager rm = new ResourceManager("RedesignWinjet3.Lang.langres", a);

            ChangeLanguage(ci, rm);
        }

        private void btFrenc_Click(object sender, EventArgs e)
        {
            CultureInfo ci = new CultureInfo("fr-FR");
            Assembly a = Assembly.Load("RedesignWinjet3");
            ResourceManager rm = new ResourceManager("RedesignWinjet3.Lang.langres", a);

            ChangeLanguage(ci, rm);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            mainTablessControl.SelectedIndex = 9;

            if (btnProcAlarm.Image != Properties.Resources.icon_22)
                btnProcAlarm.Image = Properties.Resources.icon_21;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            mainTablessControl.SelectedIndex = 10;
            if (btnNetAlarm.Image != Properties.Resources.icon_24)
                btnNetAlarm.Image = Properties.Resources.icon_23;
        }

        private void Leave_ProcAlarmTab(object sender, EventArgs e)
        {
            btnProcAlarm.Image = Properties.Resources.icon_22;
        }

        private void Leave_BusAlarmTab(object sender, EventArgs e)
        {
            btnNetAlarm.Image = Properties.Resources.icon_24;
        }

        private void listView3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }
    }
}
