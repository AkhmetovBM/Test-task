using System.Net;

namespace Weather
{
    public partial class Form1 : Form
    {
        public class WeatherForecast  //Класс для полученных данных из сайта openweathermap.org
        {           
            public string description{ get; set; }
            public string temp { get; set; }
            public string speed { get; set; }
        }
        void parsing(WeatherForecast weatherForecast, string text)//Что-то вроде Десериализации-парсинга Json файла, только куда проще)
        {
            int indexOfDescription = text.IndexOf("description")+14; //Поиск индекса где начинается описание
            string outTxt = "";
            while (text[indexOfDescription] != '"')
            {
                outTxt += text[indexOfDescription]; //Просто запись контейнера по символьно, пока не закончится
                indexOfDescription++;
            }
            weatherForecast.description=outTxt;//Запись в соответств. переменную

            indexOfDescription = text.IndexOf("temp")+6; //Копия только для температуры
            outTxt = "";
            while (text[indexOfDescription] != ',')
            {
                outTxt += text[indexOfDescription];
                indexOfDescription++;
            }
            weatherForecast.temp = outTxt;

            indexOfDescription = text.IndexOf("speed") + 7; //Копия только для скорости ветра
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
            //Строка вызова API openweather

            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            //Отправка запроса на сайт
            string response;
            using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
            {
                response = streamReader.ReadToEnd();
            }//Получение данных из запроса



            WeatherForecast weatherForecast = new WeatherForecast();
            parsing(weatherForecast, response); //Не до десериализация-парсинг для получения данных и запись в класс
            WeatherDisplay.Text = "Темпераута :" + weatherForecast.temp + 
                " градусов\nОписание :" + weatherForecast.description + 
                "\nСкорость ветра: " + weatherForecast.speed+" м/c";
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
                WeatherDisplay.Text = "Укажите город!";
        }
    }
}