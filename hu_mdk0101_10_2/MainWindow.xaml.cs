using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using Newtonsoft.Json;

namespace hu_mdk0101_10_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    ///         [Serializable]
    public class Car
    {
        public string brand { get; set; }
        public string maker { get; set; }
        public string type { get; set; }
        public int year { get; set; }
        public Car(string brand, string maker, string type, int year)
        {
            this.brand = brand;
            this.maker = maker;
            this.type = type;
            this.year = year;
        }
    }
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void SaveCarsData()
        {
            Car car1 = new Car("toyota", "Toyota corp", "sedan", 2020);
            Car car2 = new Car("audi", "audi corp", "sedan", 1974);


            //using (FileStream fileStream = new FileStream(filepath,FileMode.Create))
            //{
            //    XmlSerializer formatter = new BinaryFormatter();
            //    formatter.Serialize(fileStream, car1);
            //    formatter.Serialize(fileStream, car2);
            //}
            string filePath = "cars.json";
            string json = JsonConvert.SerializeObject(car1);
            string json2 = JsonConvert.SerializeObject(car2);
            File.WriteAllText(filePath, json);
            File.WriteAllText(filePath, json2);
            MessageBox.Show("Данные о машине сохранены в файле cars.json");
            string jsonfromfile=File.ReadAllText(filePath);
            Car deserializedcar=JsonConvert.DeserializeObject<Car>(jsonfromfile);
            Car deserializedcar2 = JsonConvert.DeserializeObject<Car>(jsonfromfile);
            MessageBox.Show($"Brand: {deserializedcar.brand}, Manufacturer: {deserializedcar.maker}, Type: {deserializedcar.type}, Year: {deserializedcar.year}");
            MessageBox.Show($"Brand: {deserializedcar2.brand}, Manufacturer: {deserializedcar2.maker}, Type: {deserializedcar2.type}, Year: {deserializedcar2.year}");
        }
        

        private void save_click(object sender, RoutedEventArgs e)
        {
            SaveCarsData();
        }
    }
}