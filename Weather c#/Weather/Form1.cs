using System.Net;

namespace Weather
{
    public partial class Form1 : Form
    {
        public class WeatherForecast  //����� ��� ���������� ������ �� ����� openweathermap.org
        {           
            public string description{ get; set; }
            public string temp { get; set; }
            public string speed { get; set; }
        }
        void parsing(WeatherForecast weatherForecast, string text)//���-�� ����� ��������������-�������� Json �����, ������ ���� �����)
        {
            int indexOfDescription = text.IndexOf("description")+14; //����� ������� ��� ���������� ��������
            string outTxt = "";
            while (text[indexOfDescription] != '"')
            {
                outTxt += text[indexOfDescription]; //������ ������ ���������� �� ���������, ���� �� ����������
                indexOfDescription++;
            }
            weatherForecast.description=outTxt;//������ � ����������. ����������

            indexOfDescription = text.IndexOf("temp")+6; //����� ������ ��� �����������
            outTxt = "";
            while (text[indexOfDescription] != ',')
            {
                outTxt += text[indexOfDescription];
                indexOfDescription++;
            }
            weatherForecast.temp = outTxt;

            indexOfDescription = text.IndexOf("speed") + 7; //����� ������ ��� �������� �����
            outTxt = "";
            while (text[indexOfDescription] != ',')
            {
                outTxt += text[indexOfDescription];
                indexOfDescription++;
            }
            weatherForecast.speed = outTxt;

        }
        private void ShowWeather(string city)
        {
            string url = "https://api.openweathermap.org/data/2.5/weather?" +
                "q=" + city + "&units=metric&lang=ru&exclude=weather,main&limit=5&appid=c5ffeb7649d5947f78965e66a5a09beb";
            //������ ������ API openweather

            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            //�������� ������� �� ����
            string response;
            using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
            {
                response = streamReader.ReadToEnd();
            }//��������� ������ �� �������



            WeatherForecast weatherForecast = new WeatherForecast();
            parsing(weatherForecast, response); //�� �� ��������������-������� ��� ��������� ������ � ������ � �����
            WeatherDisplay.Text = "���������� :" + weatherForecast.temp + 
                " ��������\n�������� :" + weatherForecast.description + 
                "\n�������� �����: " + weatherForecast.speed+" �/c";
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void ShowWeatherButton_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != null)
            {
                ShowWeather(textBox1.Text);
            }
            else
                WeatherDisplay.Text = "������� �����!";
        }
    }
}