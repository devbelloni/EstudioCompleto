using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
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
using System.Xml;
using System.Xml.Linq;
using System.Timers;
using System.Threading;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;

namespace Estudio
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly string path = "programacao.xml";
        List<string> nameList = new List<string>();
        List<string> timeList = new List<string>();
 

        public MainWindow()
        {
            InitializeComponent();

            XmlDocument xml = new XmlDocument();
            xml.Load(path);
            XmlNodeList nodeList = (xml.SelectNodes("programacao/blocos/bloco/items/item"));
            XmlNodeList nodeList1 = (xml.SelectNodes("programacao/blocos/bloco/items/item/evento/extras"));
            string name = null;
            string time = null;

            foreach (XmlNode element1 in nodeList1)
            {
                var node1 = element1?.ChildNodes[1];

                if (node1 != null)
                {
                    time = node1.LastChild?.Value;
                    timeList.Add(time);
                }
            }

            foreach (XmlNode element in nodeList)
            {
                var node = element?.ChildNodes[0]?.ChildNodes[1];

                if (node != null)
                {
                    name = node.LastChild?.Value;
                    nameList.Add(name);

                }
            }

            //            nameList.AddRange(timeList);
            ListaDeMusicas.ItemsSource = (nameList);

            /*            foreach (XmlNode element in nodeList1)
                        {
                            var node1 = element?.ChildNodes[1];

                            if (node1 != null)
                            {
                                time = node1.LastChild?.Value;
                                timeList.Add(time);
            //                    ListMusic.ItemsSource = timeList;
                              ListMusic.Items.Add(time);
            //                  ListMusic.SetBinding(ListView.ItemsSourceProperty, time);

                            }
                        }
            */





        }

        public void BtOK_Click(object sender, RoutedEventArgs e)
        {
            DateTime dateTime = DateTime.Today;
            string ipServidor = Convert.ToString(ip.Text);
            string portaServidor = Convert.ToString(porta.Text);
            string servidor = ("Servidor: " + ipServidor + " Porta: " + portaServidor + " Data: " + dateTime.ToString() + Environment.NewLine);
            if (ipServidor != "" && portaServidor != "") //Se os campos forem diferentes de vazio, o botão fica habilidado           {
                btOK.IsEnabled = true;
            File.WriteAllTextAsync("WriteText.txt", servidor);
        }
        private void BtEnviar_Ok(object sender, RoutedEventArgs e)
        {
            string mensagemServidor = Convert.ToString(mensagem.Text);
            if (mensagemServidor != "") //Se o campo for diferente de vazio, o botão fica habilidado           
            {
                btOK.IsEnabled = true;

                UDPTask(ip.Text, int.Parse(porta.Text), Encoding.ASCII.GetBytes(mensagemServidor));
            }
        }

        public void BtPlay_ClickAsync(object sender, RoutedEventArgs e)
        {
            {
                if (ip.Text != "" && porta.Text != "")
                {
                    Vs();
                }
            }
        }

        private void ListMusic_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        public void playngMusic_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        public async void Vs()
        {

            for (int i = 0; i < 15; i++)
            {
                byte[] mensagem = Encoding.ASCII.GetBytes(nameList[i]);

                UDPTask(ip.Text, int.Parse(porta.Text),mensagem);
                string palavra = nameList[i].ToString();
                playngMusic.Text = palavra;
                ListaDeMusicas.SelectedItem = i;


                int count = int.Parse(timeList[i]);


                while (count != 0)
                {

                    timerbox.Text = count.ToString();
                    count--;
                    await Task.Delay(1000);

                }
            }

        }
        public static void UDPTask(String IpDest, Int32 Port, Byte[] SendBuffer)
        {
            //IP do Destino
            IPAddress destinationIPaddress = IPAddress.Parse(IpDest);
            //EndPoint
            IPEndPoint ep = new IPEndPoint(destinationIPaddress, Port);
            //Cria a chamada Socket
            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            //Envia os dados em byteArray.
            s.SendTo(SendBuffer, ep);
            //Intervalo
            Thread.Sleep(2000);
        }
    }

}