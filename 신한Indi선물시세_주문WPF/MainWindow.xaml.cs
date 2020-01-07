using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace 신한Indi선물시세_주문WPF
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        private AxGIEXPERTCONTROLLib.AxGiExpertControl Comm_Obj_FC = new GiexpertLib.GiExpertStarter().AxGiControl;
        private AxGIEXPERTCONTROLLib.AxGiExpertControl Comm_Obj_FH = new GiexpertLib.GiExpertStarter().AxGiControl;
        private AxGIEXPERTCONTROLLib.AxGiExpertControl Comm_Obj_Order = new GiexpertLib.GiExpertStarter().AxGiControl;
        string gFCode;
        public MainWindow()
        {
            InitializeComponent();

            this.Comm_Obj_FH.ReceiveData += new AxGIEXPERTCONTROLLib._DGiExpertControlEvents_ReceiveDataEventHandler(this.Comm_Obj_FH_ReceiveData);
            this.Comm_Obj_FH.ReceiveRTData += new AxGIEXPERTCONTROLLib._DGiExpertControlEvents_ReceiveRTDataEventHandler(this.Comm_Obj_FH_ReceiveRTData);
            this.Comm_Obj_Order.ReceiveData += new AxGIEXPERTCONTROLLib._DGiExpertControlEvents_ReceiveDataEventHandler(this.Comm_Obj_Order_ReceiveData);
            this.Comm_Obj_FC.ReceiveData += new AxGIEXPERTCONTROLLib._DGiExpertControlEvents_ReceiveDataEventHandler(this.Comm_Obj_FC_ReceiveData);
            this.Comm_Obj_FC.ReceiveRTData += new AxGIEXPERTCONTROLLib._DGiExpertControlEvents_ReceiveRTDataEventHandler(this.Comm_Obj_FC_ReceiveRTData);

            FCGrid.set_TextMatrix(0, 0, "현재가");
            FCGrid.set_TextMatrix(1, 0, "등  락");
            FCGrid.set_TextMatrix(2, 0, "등락율");
            FCGrid.set_TextMatrix(3, 0, "거래량");
            FCGrid.set_TextMatrix(4, 0, "미결제");
            FCGrid.set_TextMatrix(5, 0, "시  가");
            FCGrid.set_TextMatrix(6, 0, "고  가");
            FCGrid.set_TextMatrix(7, 0, "저  가");
        }

        private void FCode_TextChanged(object sender, TextChangedEventArgs e)
        {
            string fcode = FCode.Text;

            if (fcode.Length == 5)
            {
                Comm_Obj_FC.UnRequestRTReg("FC", gFCode);
                Comm_Obj_FH.UnRequestRTReg("FH", gFCode);
                gFCode = fcode;

                Comm_Obj_FC.SetQueryName("FC");
                Comm_Obj_FC.SetSingleData(0, gFCode);
                Comm_Obj_FC.RequestData();

                Comm_Obj_FH.SetQueryName("FH");
                Comm_Obj_FH.SetSingleData(0, gFCode);
                Comm_Obj_FH.RequestData();
            }
        }

        private void Comm_Obj_FC_ReceiveData(object sender, AxGIEXPERTCONTROLLib._DGiExpertControlEvents_ReceiveDataEvent e)
        {
            Proc_FC();
        }

        private void Comm_Obj_FC_ReceiveRTData(object sender, AxGIEXPERTCONTROLLib._DGiExpertControlEvents_ReceiveRTDataEvent e)
        {
            Proc_FC();
        }

        private void Proc_FC()
        {
            FCGrid.set_TextMatrix(0, 1, (string)Comm_Obj_FC.GetSingleData(4));
            FCGrid.set_TextMatrix(1, 1, (string)Comm_Obj_FC.GetSingleData(6));
            FCGrid.set_TextMatrix(2, 1, (string)Comm_Obj_FC.GetSingleData(7));
            FCGrid.set_TextMatrix(3, 1, (string)Comm_Obj_FC.GetSingleData(8));
            FCGrid.set_TextMatrix(4, 1, (string)Comm_Obj_FC.GetSingleData(11));
            FCGrid.set_TextMatrix(5, 1, (string)Comm_Obj_FC.GetSingleData(12));
            FCGrid.set_TextMatrix(6, 1, (string)Comm_Obj_FC.GetSingleData(13));
            FCGrid.set_TextMatrix(7, 1, (string)Comm_Obj_FC.GetSingleData(14));

            Comm_Obj_FC.RequestRTReg("FC", gFCode);
        }

        private void Comm_Obj_FH_ReceiveData(object sender, AxGIEXPERTCONTROLLib._DGiExpertControlEvents_ReceiveDataEvent e)
        {
            Proc_FH();
        }

        private void Comm_Obj_FH_ReceiveRTData(object sender, AxGIEXPERTCONTROLLib._DGiExpertControlEvents_ReceiveRTDataEvent e)
        {
            Proc_FH();
        }

        private void Proc_FH()
        {
            FHGrid.set_TextMatrix(0, 0, (string)Comm_Obj_FH.GetSingleData(29));
            FHGrid.set_TextMatrix(1, 0, (string)Comm_Obj_FH.GetSingleData(23));
            FHGrid.set_TextMatrix(2, 0, (string)Comm_Obj_FH.GetSingleData(17));
            FHGrid.set_TextMatrix(3, 0, (string)Comm_Obj_FH.GetSingleData(11));
            FHGrid.set_TextMatrix(4, 0, (string)Comm_Obj_FH.GetSingleData(5));


            FHGrid.set_TextMatrix(0, 1, (string)Comm_Obj_FH.GetSingleData(27));
            FHGrid.set_TextMatrix(1, 1, (string)Comm_Obj_FH.GetSingleData(21));
            FHGrid.set_TextMatrix(2, 1, (string)Comm_Obj_FH.GetSingleData(15));
            FHGrid.set_TextMatrix(3, 1, (string)Comm_Obj_FH.GetSingleData(9));
            FHGrid.set_TextMatrix(4, 1, (string)Comm_Obj_FH.GetSingleData(3));
            FHGrid.set_TextMatrix(5, 1, (string)Comm_Obj_FH.GetSingleData(4));
            FHGrid.set_TextMatrix(6, 1, (string)Comm_Obj_FH.GetSingleData(10));
            FHGrid.set_TextMatrix(7, 1, (string)Comm_Obj_FH.GetSingleData(16));
            FHGrid.set_TextMatrix(8, 1, (string)Comm_Obj_FH.GetSingleData(22));
            FHGrid.set_TextMatrix(9, 1, (string)Comm_Obj_FH.GetSingleData(28));

            FHGrid.set_TextMatrix(5, 2, (string)Comm_Obj_FH.GetSingleData(6));
            FHGrid.set_TextMatrix(6, 2, (string)Comm_Obj_FH.GetSingleData(12));
            FHGrid.set_TextMatrix(7, 2, (string)Comm_Obj_FH.GetSingleData(18));
            FHGrid.set_TextMatrix(8, 2, (string)Comm_Obj_FH.GetSingleData(24));
            FHGrid.set_TextMatrix(9, 2, (string)Comm_Obj_FH.GetSingleData(30));
        }

        private void BtSell_Click(object sender, RoutedEventArgs e)
        {
            Send_Order(false);
        }

        private void BtBuy_Click(object sender, RoutedEventArgs e)
        {
            Send_Order(true);
        }

        private void Send_Order(bool bBuy)
        {
            string strAcct = AcctNo.Text;
            string strpwd = PWD.Text;
            string strPrice = Price.Text;
            string strQty = Qty.Text;
            string strOrder = "01";
            if (strAcct.Length != 11 || strpwd.Length != 4)
            {
                MessageBox.Show("계좌비번을 확인하세요");
                return;
            }

            if (bBuy)
                strOrder = "02";

            Comm_Obj_Order.SetQueryName("SABC100U1");

            Comm_Obj_Order.SetSingleData(0, strAcct);						// 계좌번호
            Comm_Obj_Order.SetSingleData(1, strpwd);						// 비밀번호
            Comm_Obj_Order.SetSingleData(2, gFCode);					    // 종목코드
            Comm_Obj_Order.SetSingleData(3, strQty);						// 주문수량
            Comm_Obj_Order.SetSingleData(4, strPrice);						// 주문단가
            Comm_Obj_Order.SetSingleData(5, "0");							// 주문조건
            Comm_Obj_Order.SetSingleData(6, strOrder);						// 매매구분
            Comm_Obj_Order.SetSingleData(7, "L");							// 호가유형
            Comm_Obj_Order.SetSingleData(8, "3");							// 차익거래구분							
            Comm_Obj_Order.SetSingleData(9, "1");							// 처리구분
            Comm_Obj_Order.SetSingleData(10, "0");							// 정정취소수량구분
            Comm_Obj_Order.SetSingleData(11, "0");							// 정정취소수량구분

            if (Comm_Obj_Order.RequestData() <= 0)
                MessageBox.Show("주문전송실패");
        }

        private void Comm_Obj_Order_ReceiveData(object sender, AxGIEXPERTCONTROLLib._DGiExpertControlEvents_ReceiveDataEvent e)
        {
            string strOrderNo;

            strOrderNo = (string)Comm_Obj_Order.GetSingleData(0);
            var cc = Comm_Obj_Order.GetMultiBlockData();
            var vv = Comm_Obj_Order.GetSingleBlockData();
            //MessageBox.Show(strOrderNo);
        }
    }

    class ExampleDataItem
    {
        public string Column1 { get; set; }
        public string Column2 { get; set; }
        public string Column3 { get; set; }
    }

    static class ExMethods
    {

        public static void set_TextMatrix(this DataGrid dGrid, int row, int column, string data)
        {
            App.Current.Dispatcher.Invoke(() =>
            {
                try
                {
                    ExampleDataItem curItem;
                    while (dGrid.Items.Count - 1 < row)
                    {
                        dGrid.Items.Add(new ExampleDataItem());
                    }
                    curItem = dGrid.Items[row] as ExampleDataItem;
                    switch (column)
                    {
                        case 0:
                            curItem.Column1 = data;
                            break;
                        case 1:
                            curItem.Column2 = data;
                            break;
                        case 2:
                            curItem.Column3 = data;
                            break;
                    }
                    dGrid.Items[row] = curItem;

                    dGrid.Items.Refresh();
                }
                catch (TaskCanceledException)
                {
                    return;
                }
            }, DispatcherPriority.Send);
        }
    }
}
