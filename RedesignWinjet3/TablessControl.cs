using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RedesignWinjet3
{
    class TablessControl: TabControl
    {
        protected override void WndProc(ref Message m)
        {
            if(m.Msg == 0x1328 && !DesignMode) m.Result = (IntPtr)1;
            else base.WndProc(ref m);
        }

        public TablessControl()
        {
            OnLoadTab();
        }

        public delegate void LoadTabControl(object sender, EventArgs args);

        public event LoadTabControl LoadTab;

        protected virtual void OnLoadTab()
        {
            if (LoadTab != null)
                LoadTab(this, EventArgs.Empty);

        }
        
    }
}
