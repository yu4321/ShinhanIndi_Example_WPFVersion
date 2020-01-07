using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GiexpertLib
{
    public partial class GiExpertAx: UserControl
    {
        public AxGIEXPERTCONTROLLib.AxGiExpertControl axGiExpert { get; set; }
        public GiExpertAx()
        {
            InitializeComponent();
            axGiExpert = axGiExpertControl1;
            axGiExpertControl1.StartIndi("", "", "", @"C:\SHINHAN-i\indi\giexpertstarter.exe");
        }
    }
}
