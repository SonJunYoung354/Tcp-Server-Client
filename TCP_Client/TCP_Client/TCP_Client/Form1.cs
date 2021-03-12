using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Net.NetworkInformation;
using MySql.Data.MySqlClient;



namespace TCP_Client
{
    public partial class Form1 : Form
    {


       
        

        // 각종 전역 변수 선언

        NetworkStream _ntstream;
        StreamReader _streader;
        StreamWriter _stwriter;
        Thread _thread_receive;
        TcpClient _client;
        // 서버 오픈 여부 확인 디폴트 = Flase;
        bool _connect_flag = false;
        // 메소드를 참조하는 델리 게이트 변수 선언
        delegate void D_receive(string data);
        public Form1()
        {
            InitializeComponent();
        }
        private void DoThread()
        {
            for (int i = 0; i < 10; i++)
            {

                Console.WriteLine("DoThread : {0}", i);
            }
        }
        private void DoThread1(object obj)
        {
            for (int i = 0; i < (int)obj; i++)
            {
                Console.WriteLine("DoThread1 : {0}", i);
            }
        }
        



        private void pictureBox8_Click(object sender, EventArgs e)
        {
            try
            {
                // 현재 접속중인지 아닌지 판단.
                if (!_connect_flag)
                {
                    //텍스트 박스 값으로 TcpClient 생성 (int.parse 는 텍스트를 숫자화 하는 메서드)
                    _client = new TcpClient(tb_ip.Text, int.Parse(tb_port.Text));
                    //접속하였기 때문에 접속 플래그를 True로 변경
                    _connect_flag = true;
                    //접속한 Cilent에서 networkstream을 추출
                    _ntstream = _client.GetStream();
                    //추출한 networkstream으로 streamreader,writer 생성
                    _streader = new StreamReader(_ntstream);                             
                    _stwriter = new StreamWriter(_ntstream);
                    //클라이언트의 ReceiveTimeout설정 500
                    _client.ReceiveTimeout = 500;
                    //receive메서드 스레드로 생성
                    _thread_receive = new Thread(receive);
                    //스레드 시작
                    _thread_receive.Start();                                              
                    tb_recevie_text("접속이 성공하였습니다.\r\n");
                    bt_send.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                //실패할경우 접속이 취소되었음으로 플래그를 false로 변경
                _connect_flag = false;                                                    
                MessageBox.Show("접속에 실패하였습니다");
            }
        }

        string localIP = "";//전역변수


        // IP 알아내는메소드
        public string GetLocalIP() 

        {

            localIP = "Not available, please check your network seetings!";

            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());

            foreach (IPAddress LocalIPAddress in host.AddressList)

            {

                if (LocalIPAddress.AddressFamily == AddressFamily.InterNetwork)

                {

                    localIP = LocalIPAddress.ToString();

                    break;

                }

            }

            return localIP;

        }


        void receive()
        {
            try
            {
                //현재 접속중인지 아닌지 판단
                while (_connect_flag)                                                     
                {
                    //streamreader의 한줄을 읽어들여 string 변수에 저장
                    string receive_data = _streader.ReadLine();
                    //data가 null이 아니면
                    if (receive_data != null)                                            
                    {
                        //텍스트박스에 텍스트를 추가하는 메서드
                        tb_recevie_text(receive_data);                                        
                    }

                }

            }
            //IO에러 (Timeout에러도 이쪽으로 걸림)
            catch (IOException)                                                           
            {
                //현재 접속중인지 아닌지 체크
                if (_connect_flag)                                                        
                {
                    //접속중일 경우 receive메서드를 이용한 스레드 다시생성
                    _thread_receive = new Thread(receive);                               
                    _thread_receive.Start();
                }
                else
                {
                    //접속중이 아닐경우 자연스럽게 스레드 정지
                    _connect_flag = false;                                                
                }
            }
            //그 밖의 에러
            catch (Exception ex)                                                         
            {
                _connect_flag = false;                                                    
                MessageBox.Show(ex.ToString());                                          
            }
        }
        private void pictureBox10_Click(object sender, EventArgs e)
        {

            try
            {
                //현재 접속중인지 아닌지 체크
                if (_connect_flag)                                                       
                {
                    if (_ntstream.CanRead)
                    {
                        //전송할 내용이 담긴 TextBox가 비었는지 체크
                        if (tb_writeline.Text != string.Empty)                               
                        {
                            //StreamWriter 버퍼에 텍스트박스 내용 저장
                            tb_receive.AppendText(tb_ID.Text + " : " + tb_writeline.Text + "\r\n");
                            //StreamWriter 버퍼에 텍스트박스 내용 저장
                            _stwriter.WriteLine(tb_ID.Text + " : " + tb_writeline.Text);
                            //StreamWriter 버퍼 내용을 스트림으로 전달
                            _stwriter.Flush();                                                
                            tb_writeline.Text = null;
                        }
                    }
                }
            }
            catch (Exception ex)                                                          
            {
                //접속이 취소되었음으로 플래그를 false로 변경
                _connect_flag = false;                                                   
                MessageBox.Show(ex.ToString());                                          

            }
        }
        //텍스트박스에 텍스트 추가하는 메서드
        void tb_recevie_text(string data)                                                 
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new D_receive(tb_recevie_text), data);
            }
            else
            {
                if (data != null)                                                         
                {
                    //텍스트박스에 데이터+개행문자 추가
                    tb_receive.AppendText(data + "\r\n");                                 

                }
            }
        }

        private void bt_send_Click(object sender, EventArgs e)                            
        {
            try
            {
                //현재 접속중인지 아닌지 체크
                if (_connect_flag)                                                        
                {
                    if (_ntstream.CanRead)
                    {      //전송할 내용이 담긴 TextBox가 비었는지 체크
                        if (tb_writeline.Text != string.Empty)                                
                        {
                            tb_receive.AppendText(tb_ID.Text + " : " + tb_writeline.Text + "\r\n");
                            //StreamWriter 버퍼에 텍스트박스 내용 저장
                            _stwriter.WriteLine(tb_ID.Text + " : " + tb_writeline.Text);
                            //StreamWriter 버퍼 내용을 스트림으로 전달
                            _stwriter.Flush();                                                
                            tb_writeline.Text = null;
                        }
                    }
                }
            }
            catch (Exception ex)                                                          
            {
                _connect_flag = false;                                                    
                MessageBox.Show(ex.ToString());                                           

            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)             
        {
            if (_connect_flag)
            {
                if (_ntstream.CanRead)
                {
                    _stwriter.WriteLine(tb_ID.Text + "의 연결이 끊어졌습니다. ");                           
                    _stwriter.Flush();
                    _ntstream.Close();
                }
                _connect_flag = false;
            }
            //접속중인지 체크하는 _connect_flag를 false로 변경
        }

       
        private void button2_Click(object sender, EventArgs e)
        {
            if (_connect_flag == true)
            {

                MessageBox.Show("연결을 종료합니다");
                tb_receive.AppendText("서버와 연결을 종료합니다.\r\n");
                _connect_flag = false;

            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            //현재 시간 날짜 시 분 초 생성 라벨
            label4.Text = DateTime.Now.ToString("yyyy-MM-dd");
            label5.Text = DateTime.Now.ToString("HH:mm");
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            // 원폼 종료 메서드
            Application.Exit(); 

        }

        private void iPEndPointToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IPAddress IPInfo = IPAddress.Parse("127.0.0.1");
            int Port = 8000;

            IPEndPoint EndpointInfo = new IPEndPoint(IPInfo, Port);

            string message;
            message = string.Format("본인의 DNS{0} {1} :", IPInfo, Port);
            MessageBox.Show(message);


            //Console.Write("IP:Port = ");
            //Console.WriteLine(EndpointInfo.ToString());

        }

        private void iPHostEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IPHostEntry HostInfo = Dns.GetHostEntry("www.naver.com");

            foreach (IPAddress IP in HostInfo.AddressList)
            {

                /*string message;
                message = string.Format("본인의 DNS{0} :    ", HostInfo);*/



            }

        }

        private void dnsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IPAddress[] IP = Dns.GetHostAddresses("www.google.co.kr");

            foreach (IPAddress HostIP in IP)
            {
                string message;
                message = string.Format("본인의 DNS{0} :", HostIP);
                MessageBox.Show(message);
            }

        }

        private void iPAddressToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string message;
            GetLocalIP();
            localIP.ToString();

            message = string.Format("본인의 IP주소 : {0}", localIP);
            MessageBox.Show(message);
        }

        private void tcpListenerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string message;
            IPAddress ip = IPAddress.Parse("127.0.0.1");

            TcpListener tcpListener = new TcpListener(ip, 5000);
            message = string.Format("aaa {0}", tcpListener.LocalEndpoint.ToString());
            MessageBox.Show(message);
            //Console.WriteLine("Server Side Adderess Info. :");
            //Console.WriteLine("{0}", tcpListener.LocalEndpoint.ToString());

        }

        private void acceptTcpClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TcpListener tcpListener = new TcpListener(IPAddress.Parse("127.0.0.1"), 5000);
            tcpListener.Start();        // 동작을 시켜야 한다...

            MessageBox.Show("대기상태");

            TcpClient tcpClient = tcpListener.AcceptTcpClient();    // 대기상태~~~~~~ 

            MessageBox.Show("대기상태 종료");
            tcpListener.Stop();

        }

        private void tcpClientToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void networkStreamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // (1) IP 주소와 포트를 지정하고 TCP 연결 
            TcpClient tc = new TcpClient("127.0.0.1", 7000);
            //TcpClient tc = new TcpClient("localhost", 7000);

            string msg = "Hello World";
            byte[] buff = Encoding.ASCII.GetBytes(msg);

            // (2) NetworkStream을 얻어옴 
            NetworkStream stream = tc.GetStream();

            // (3) 스트림에 바이트 데이타 전송
            stream.Write(buff, 0, buff.Length);

            // (4) 스트림으로부터 바이트 데이타 읽기
            byte[] outbuf = new byte[1024];
            int nbytes = stream.Read(outbuf, 0, outbuf.Length);
            string output = Encoding.ASCII.GetString(outbuf, 0, nbytes);

            // (5) 스트림과 TcpClient 객체 닫기
            stream.Close();
            tc.Close();

            Console.WriteLine($"{nbytes} bytes: {output}");
        }

        private void tcpServerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TcpListener tcpListener = new TcpListener(IPAddress.Parse("127.0.0.1"), 8000);      // 서버측~~
            tcpListener.Start();        // 시작 -> 대기상태로 진입~~

            MessageBox.Show("TCP_Server 대기상태");

            TcpClient tcpClient = tcpListener.AcceptTcpClient();    // 여기에서 계속 대기한다..

            NetworkStream ns = tcpClient.GetStream();
            byte[] resMessage = new byte[100];      // 최대 100 바이트 
            ns.Read(resMessage, 0, 100);            // 0부터 시작해서 100개를 읽어온다,..,...
            string strMessage = Encoding.ASCII.GetString(resMessage);

            MessageBox.Show("[서버] 수신 : " + strMessage);          // 수신 데이터 출력~~

            string EchoMessage = "Hi Client I'm Server~~";
            MessageBox.Show("[서버] 송신 : " + EchoMessage);

            Byte[] sendMessage = Encoding.ASCII.GetBytes(EchoMessage);  // GetBytes로 
            ns.Write(sendMessage, 0, sendMessage.Length);
            ns.Close();

            tcpClient.Close();
            tcpListener.Stop();

        }

        private void 사용Port리스트ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Console.WriteLine("Active TCP Listeners");
            IPGlobalProperties properties = IPGlobalProperties.GetIPGlobalProperties();
            IPEndPoint[] endPoints = properties.GetActiveTcpListeners();
            foreach (IPEndPoint ex in endPoints)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void 스레드생성ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread th1 = new Thread(new ThreadStart(DoThread));
            th1.Start();
        }

        private void 스레드에변수넘기기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int i = 10;

            Thread th1 = new Thread(new ParameterizedThreadStart(DoThread1));
            th1.Start(i);

        }
        class testClass
        {
            public void Print()
            {
                Console.WriteLine("스레드에 메서드 넘겨서 실행");
            }
        }


        private void 객체의메서드넘기기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            testClass test = new testClass();

            Thread th1 = new Thread(new ThreadStart(test.Print));
            th1.Start();
        }


        private void fun1()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("스레드1 실행 : {0}", i);
            }
        }
        private void fun2()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("스레드2 실행 : {0}", i);
            }

        }

        private void 다수의스레드함수호출ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread th1 = new Thread(new ThreadStart(fun1));
            Thread th2 = new Thread(new ThreadStart(fun2));
            th1.Start();
            th2.Start();



        }

        private void 다수의객체메서드호출ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            testClass test1 = new testClass();
            testClass test2 = new testClass();

            Thread th1 = new Thread(new ThreadStart(test1.Print));
            Thread th2 = new Thread(new ThreadStart(test2.Print));
            th1.Start();
            th2.Start();

        }

        private void 다수의스레드함수반복ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread th1 = new Thread(new ThreadStart(fun1));
            Thread th2 = new Thread(new ThreadStart(fun2));
            th1.Start();
            th2.Start();
        }

        private void 스레드종료ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            testClass te1 = new testClass();
            testClass te2 = new testClass();

            Thread th1 = new Thread(new ThreadStart(te1.Print));
            Thread th2 = new Thread(new ThreadStart(te2.Print));
            th1.Start();
            th2.Start();
            th1.Join(); // 작업 후 스레드 종료
            th1.Abort(); // 스레드 강제 종료
            th1.Abort();
        }

        private void streamWriteReadToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }

        private void readToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            // 파일 절대 경로 생성
            string text = File.ReadAllText(@"D:\학업\4학년\네트워크프로그래밍\기말3\TCP_Client\TCP_Client\Test\15110073.txt");
            textBox4.Text = text;
          
        }
        void a1_WriteTextEvent(string text)

        {

            this.textBox4.Text = text;

        }



        private void writeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] lines = { "First line", "Second line", "Third line" };
            //파일 경로 
            using (StreamWriter outputFile = new StreamWriter(@"D:\학업\4학년\네트워크프로그래밍\기말3\TCP_Client\TCP_Client\Test\15110073.txt"))
            {
                foreach (string line in lines)
                {
                    outputFile.WriteLine(line);
                }
            }

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            // 원폼 종료 메서드
            Application.Exit();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("프로젝트 test 폴더 안 txt 파일 내용을 불러옵니다");
            string text = File.ReadAllText(@"D:\학업\4학년\네트워크프로그래밍\기말3\TCP_Client\TCP_Client\Test\15110073.txt");
            textBox4.Text = text;

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Form2 a1 = new Form2();
            // Form2 Show
            a1.Show();
            // 생성 당시 이벤트 등록
            a1.WriteTextEvent += new Form2.TextEventHandler(a1_WriteTextEvent); // 생성 당시 이벤트 등록


            a1.received2(textBox4.Text);

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            //로컬 ip 변수 저장 함수 호출
            GetLocalIP();


            MessageBox.Show("브로드캐스트 주소, 루프백 주소, 본인 ip를 출력합니다");
            // 브로드 캐스트
            IPAddress add1 = IPAddress.Broadcast;
            // 루프백 주소
            IPAddress add2 = IPAddress.Loopback;     

            string ad1 = add1.ToString();
            string ad2 = add2.ToString();

            textBox1.Text = ad1;
            textBox2.Text = ad2;
            textBox3.Text = localIP;
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

            if (_connect_flag == true)
            {

                MessageBox.Show("연결을 종료합니다");
                tb_receive.AppendText("서버와 연결을 종료합니다.\r\n");
                _connect_flag = false;

            }
            else
            {
                MessageBox.Show("접속중이 아닙니다");
            }
        }
        // 파일 전송
        private void pictureBox4_Click_1(object sender, EventArgs e) 
        {
            //소켓 생성
            Socket mysocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //소켓 연결
            mysocket.Connect("169.254.186.162", 5300);
            //텍스트 파일
            FileStream FileStr = new FileStream("test1.txt", FileMode.Open, FileAccess.Read);
            // 크기 저장
            int FileLen = (int)FileStr.Length;
            //버퍼에 담아둠
            byte[] buffer = BitConverter.GetBytes(FileLen);
            mysocket.Send(buffer);
            int count = FileLen / 1024 + 1;
            BinaryReader rea = new BinaryReader(FileStr);

            for(int i = 0; i< count; i++)
            {
                buffer = rea.ReadBytes(1024);
                mysocket.Send(buffer);
            }

            rea.Close();
            mysocket.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            Form3 a1 = new Form3();
            // Form2 Show
            a1.Show();


            /*MySqlConnection connection = new MySqlConnection("Server=localhost;Database=demo;port=3305;Uid=root;Pwd=root;");


            try
            {
                string myCon = "datasource=localhost;port=3305;username=root;password=root";
                MySqlConnection myConn = new MySqlConnection(myCon);
                MySqlDataAdapter mydata = new MySqlDataAdapter();
                mydata.SelectCommand = new MySqlCommand("SELECT * database.demo;", myConn);
                MySqlCommandBuilder cb = new MySqlCommandBuilder(mydata);
                DataSet ds = new DataSet();
                MessageBox.Show("연결되었습니다");
                myConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           */


        }
    }
}