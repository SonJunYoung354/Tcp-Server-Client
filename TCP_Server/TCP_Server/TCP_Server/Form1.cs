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
using System.Threading;
using System.IO;
namespace TCP_Server
{
    public partial class Form1 : Form
    {

        //전역 변수 선언부
        TcpListener _tcpLitener;
        bool _open_flag = false;
        Thread _thread_listener;
        Thread _thread_receive;
        NetworkStream _ntstream;
        StreamReader _streader;
        StreamWriter _stwriter; 
        TcpClient _client;
        // 대리자 델리게이트 생성 [ 클라이언트랑 동일 ! 
        delegate void D_receive(string data); 

        public Form1()
        {
            InitializeComponent();
        }

        private void bt_open_Click(object sender, EventArgs e)
        {
            try
            {
                //현재 접속중인지 아닌지 판단
                if (!_open_flag)                                                                       
                {
                    //텍스트 박스 값으로 TcpListener 생성
                    _tcpLitener = new TcpListener(IPAddress.Parse(tb_ip.Text), int.Parse(tb_port.Text));
                    _tcpLitener.Start();
                    //서버를 오픈하였기 때문에 오픈 플래그를 True로 변경
                    _open_flag = true;
                    //listener메서드 스레드로 생성
                    _thread_listener = new Thread(listener);
                    //스레드 시작
                    _thread_listener.Start();                                                                  
                    tb_recevie_text("서버가 시작되었습니다.\r\n");
                    bt_send.Enabled = true;
                    
                }
            }
            catch (Exception ex)                                                                       
            {
                //실패할경우 오픈이 취소되었음으로 플래그를 false로 변경
                _open_flag = false;                                                                     
                MessageBox.Show(ex.ToString());      
            }
        }
        //접속 Client를 받아들이는 메소드
        void listener()                                                                               
        {
            try
            {
                //현재 오픈중인지 아닌지 판단
                if (_open_flag)                                                                         
                {
                    //Client가 접속할경우 Client변수 생성
                    _client = _tcpLitener.AcceptTcpClient();                                   
                    tb_recevie_text("Client가 접속하였습니다\r\n");
                    //접속한 Client로 create_stream메소드 실행
                    create_stream();                                                              
                }
                else
                {
                    tb_recevie_text("서버가 열리지 않았습니다\r\n");
                }
            }
            //에러
            catch (Exception ex)                                                                    
            {  
                MessageBox.Show(ex.ToString());
            }
        }
        void create_stream()                                                            
        {
            try
            {
                //접속한 Client에서 networkstream 추출
                _ntstream = _client.GetStream();
                //Client의 ReceiveTimeout
                _client.ReceiveTimeout = 500;
                //추출한 networkstream으로 streamreader,writer 생성
                _streader = new StreamReader(_ntstream);                                               
                _stwriter = new StreamWriter(_ntstream);
                //receive메서드 스레드로 생성
                _thread_receive = new Thread(receive);
                //스레드 시작  
                _thread_receive.Start();                                                                
            }
            //에러
            catch (Exception ex)                                                                        
            {
                _open_flag = false;                                                                     
                MessageBox.Show(ex.ToString());
            }
        }
        void receive()
        {
            try
            {
                //현재 오픈중인지 아닌지 판단
                while (_open_flag)                                                                         
                {
                    //streamreader의 한줄을 읽어들여 string 변수에 저장  
                    string _receive_data = _streader.ReadLine();                                                                       
                    if (_receive_data != null)                                                             
                    {
                        tb_recevie_text(_receive_data);   
                    }
                }
                
            }
            //IO에러 (Timeout에러도 이쪽으로 걸림)
            catch (IOException)                                                                                         
            {
                if (_open_flag)                                                                          
                {
                    //접속중일 경우 receive메서드를 이용한 스레드 다시생성
                    _thread_receive = new Thread(receive);                                                
                    _thread_receive.Start();
                }                                                                                        
            }
            // 그밖의 에러
            catch (Exception ex)                                                                         
            {
                _open_flag = false;

                tb_recevie_text("클라이언트의 연결이 종료되었습니다\r\n다시 서버오픈을 시도합니다.\r\n"); 
                _tcpLitener.Stop();
                bt_open_Click(null, null);
            }
        }
        //텍스트박스에 텍스트 추가하는 메서드
        void tb_recevie_text(string data)                                               
        {
            if (this.InvokeRequired)
            {
                //대리자 델리게이트 호출 
                this.Invoke(new D_receive(tb_recevie_text), data);                        
            }
            else
            {
                if (data != null)                                                         
                {
                    tb_receive.AppendText(data + "\r\n");                                 
                }
            }
        }
        private void bt_send_Click(object sender, EventArgs e)
        {
            try
            {
                if (_open_flag)                                                        
                {
                    //전송할 내용이 담긴 TextBox가 비었는지 체크
                    if (tb_writeline.Text != string.Empty)                               
                    {
                        tb_receive.AppendText(tb_ID.Text+" : " +tb_writeline.Text + "\r\n");
                        //StreamWriter 버퍼에 텍스트박스 내용 저장
                        _stwriter.WriteLine(tb_ID.Text + " : " + tb_writeline.Text);
                        //StreamWriter 버퍼 내용을 스트림으로 전달
                        _stwriter.Flush();                                              
                        tb_writeline.Text = null;
                    }
                }
            }
            catch (Exception ex)                                                           
            {
                _open_flag = false;                                                   
                
                MessageBox.Show(ex.ToString());                                          

            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)                            
        {
            if (_open_flag)
            {
	            if (_ntstream.CanRead )
	            {
	                _stwriter.WriteLine(tb_ID.Text + "의 연결이 끊어졌습니다. ");                          
	                _stwriter.Flush();
	                _ntstream.Close();
	            }
	            _open_flag = false;          
            }
                                                                 
        }

        //파일 전송하는 이벤트
        private void File_Click(object sender, EventArgs e)
        {
            Socket mysocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            IPAddress ip = IPAddress.Parse("127.0.0.1");
            IPEndPoint point = new IPEndPoint(ip,5300);

            mysocket.Bind(point);
            mysocket.Listen(1);
            mysocket = mysocket.Accept();
            byte[] buffer = new byte[4];
            mysocket.Receive(buffer);
            int fileLength = BitConverter.ToInt32(buffer, 0);

            buffer = new byte[1024];
            int totalLength = 0;
            FileStream fileStr = new FileStream("test1", FileMode.Create, FileAccess.Write);

            BinaryWriter writer = new BinaryWriter(fileStr);

            while(totalLength < fileLength)
            {
                int receiveLength = mysocket.Receive(buffer);

                writer.Write(buffer, 0, receiveLength);

                totalLength += receiveLength;
            }

            writer.Close();
            mysocket.Close();
        
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

       
    }
}
