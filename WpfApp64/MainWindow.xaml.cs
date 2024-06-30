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

namespace WpfApp64
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
            string vehicleType = VehicleType.Text;
            string region = Region.Text;
            int age = int.Parse(Age.Text);
            int experience = int.Parse(Experience.Text);
            int power = int.Parse(Power.Text);

            double tb = GetBaseTariff(vehicleType);
            double kt = GetRegionCoefficient(region);
            double kve = GetAgeExperienceCoefficient(age, experience);
            double km = GetPowerCoefficient(power);
            double kbm = GetBonusCoefficient(experience);

            double osagoCost = tb * kt * kve * km * kbm;
            Result.Text = $"Стоимость ОСАГО: {osagoCost:F2} руб.";
        }

        private double GetBaseTariff(string vehicleType)
        {
            switch (vehicleType)
            {
                case "Мотоциклы, мотороллеры (категории А)":
                    return 1215;
                case "Легковые автомобили (категории В)":
                    return 1980;
                case "Грузовые автомобили (категории С)":
                    return 2025;
                default:
                    return 0;
            }
        }

        private double GetRegionCoefficient(string region)
        {
            switch (region)
            {
                case "Пенза":
                    return 1.4;
                case "Кузнецк":
                    return 1.0;
                case "Прочие города Пензенской области":
                    return 0.7;
                case "Сызрань":
                    return 1.1;
                case "Самара":
                    return 1.6;
                case "Тольятти":
                    return 1.5;
                case "Прочие города Самарской области":
                    return 0.9;
                case "Димитровград":
                    return 1.1;
                case "Ульяновск":
                    return 1.4;
                case "Прочие города Ульяновской области":
                    return 0.8;
                default:
                    return 0;
            }
        }

        private double GetAgeExperienceCoefficient(int age, int experience)
        {
            if (age <= 22 && experience <= 3)
                return 1.8;
            else if (age <= 22 && experience > 3)
                return 1.6;
            else if (age > 22 && experience <= 3)
                return 1.7;
            else
                return 1.0;
        }

        private double GetPowerCoefficient(int power)
        {
            if (power <= 50)
                return 0.6;
            else if (power <= 70)
                return 1.0;
            else if (power <= 100)
                return 1.1;
            else if (power <= 120)
                return 1.2;
            else if (power <= 150)
                return 1.4;
            else
                return 1.6;
        }

        private double GetBonusCoefficient(int experience)
        {
            return 3.92 - 0.173 * experience;
        }
    }
}