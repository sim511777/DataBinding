using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            textBox1.DataBindings.Add("Text", textBox2, "Text", false, DataSourceUpdateMode.OnPropertyChanged);

            // 데이터 바인딩 추가
            textBox4.DataBindings.Add("Text", source, "Text", false, DataSourceUpdateMode.OnPropertyChanged);
            //source.PropertyChanged += (s, e) => { textBox4.Text = source.Text; };
            //textBox4.TextChanged += (s, e) => { source.Text = textBox4.Text; };
        }

        Source source = new Source();

        // 소스 변경
        private void textBox3_TextChanged(object sender, EventArgs e) {
            source.Text = textBox3.Text;
        }

        // 소스 확인
        private void button1_Click(object sender, EventArgs e) {
            this.Text = source.Text;
        }
    }

    class Source : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;

        private string text;
        // set 속성에서 이벤트 호출
        public string Text {
            get { return text; }
            set { text = value; NotifyPropertyChanged(); }
        }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "") {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
