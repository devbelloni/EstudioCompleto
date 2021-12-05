using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Xml;

namespace Estudio
{
    /// Marcio Belloni - Data:04/12/2021 - V1.0
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly string path = "programacao.xml"; // Cria o caminho para o xml

        public MainWindow()
        {
            InitializeComponent();

            XmlDocument xml = new XmlDocument();
            xml.Load(path);
            XmlNodeList nodeList = xml.SelectNodes("programacao/blocos/bloco/items/item"); // adiciona ao Nodelist a lista do xml

            var listaGrid = new List<Playlist>();

 

            // Criar a lista com o nome e duração das músicas e subir para o Datagrid
            foreach (XmlNode element in nodeList)
            {
                XmlNode node = element?.ChildNodes[0]?.ChildNodes[1];

                if (node != null)
                {  //Identifica e instancia as strings
                    var name = node.LastChild?.Value;
                    var time = node.NextSibling?.ChildNodes[1]?.InnerText;
                    // Alimenta a listaGrid com a informação
                    listaGrid.Add(new Playlist { Nome = name, Tempo = time });
                }

            }
            // Envia ao Datagrid a lista.
            dataGrid.ItemsSource = listaGrid;
        }
        // Método para o botão de Servidor
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
        // Método do botão de enviar
        private void BtEnviar_Ok(object sender, RoutedEventArgs e)
        {
            string mensagemServidor = Convert.ToString(mensagem.Text);
            if (mensagemServidor != "") //Se o campo for diferente de vazio, o botão fica habilidado           
            {
                btOK.IsEnabled = true;

                UDPTask(ip.Text, int.Parse(porta.Text), Encoding.ASCII.GetBytes(mensagemServidor));
            }
        }
        // Botão de iniciar o player
        public void BtPlay_ClickAsync(object sender, RoutedEventArgs e)
        {
            {
                if (ip.Text != "" && porta.Text != "")
                {
                    Vs();
                }
            }
        }
        public void playngMusic_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        // Cria ao método assíncrono para contagem do tempo

        public async void Vs()
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(path);
            XmlNodeList nodeList = (xml.SelectNodes("programacao/blocos/bloco/items/item"));
            XmlNodeList nodeList1 = (xml.SelectNodes("programacao/blocos/bloco/items/item/evento/extras"));
            List<string> nameList = new List<string>();
            List<string> timeList = new List<string>();

            foreach (XmlNode element in nodeList)
            {
                var node = element?.ChildNodes[0]?.ChildNodes[1];

                if (node != null)
                {
                    var name = node.LastChild?.Value;
                    nameList.Add(name);
                }
            }
            foreach (XmlNode element in nodeList1)
            {
                var node1 = element?.ChildNodes[1];

                if (node1 != null)
                {
                    var time = node1.InnerText;
                    timeList.Add(time);
                }
            }

            for (int i = 0; i < 15; i++)
            {
                byte[] mensagem = Encoding.ASCII.GetBytes(nameList[i]);

                UDPTask(ip.Text, int.Parse(porta.Text),mensagem);
                string palavra = nameList[i].ToString();
                playngMusic.Text = palavra;

                int count = int.Parse(timeList[i]);

                while (count != 0)
                {
                    timerbox.Text = count.ToString();
                    count--;
                    await Task.Delay(1000);
                }
            }
        }
        // Método para o envio das mensagens UDP
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
    // Cria a classe para o playlist.
    public class Playlist
    {
        public string Nome { get; set; }
        public string Tempo { get; set; }
    }
}