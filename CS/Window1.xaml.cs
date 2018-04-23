using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using DevExpress.Data;

namespace RowsHitTest {
 
    public partial class Window1 : Window {

        List<TestData> list;

        public Window1() {
            InitializeComponent();

            #region Data Binding
            list = new List<TestData>();
            for(int i = 0; i < 100; i++) {
                list.Add(new TestData() { Text = "row " + i, Number = i });
            }

            grid.ItemsSource = list;
            #endregion

            #region #MouseEvents
            view.MouseDown += new MouseButtonEventHandler(OnMouseEvent);
            view.MouseUp += new MouseButtonEventHandler(OnMouseEvent);
            view.MouseDoubleClick += new MouseButtonEventHandler(OnMouseEvent);
            #endregion
        }

        #region #MouseEventHandler
        void OnMouseEvent(object sender, MouseEventArgs e) {
            int rowHandle = view.GetRowHandleByMouseEventArgs(e);

            if(rowHandle != GridDataController.InvalidRow) {
                eventLog.Text += 
                    string.Format("row index: {0}, event: {1}\r\n",
                    grid.GetListIndexByRowHandle(rowHandle), e.RoutedEvent.Name);

                eventLog.ScrollToEnd();
            }
        }
        #endregion
    }

    #region TestData
    public class TestData {
        public string Text { get; set; }
        public int Number { get; set; }
    }
    #endregion
}
