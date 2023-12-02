using CaptchaFacil;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private CaptchaImage captchaImage;
        private CaptchaResult currentCaptcha;

        public Form1()
        {
            InitializeComponent();
            captchaImage = new CaptchaImage();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (currentCaptcha.CaptchaText == textBox1.Text)
            {
                MessageBox.Show("Captcha Ok");
            }
            else
            {
                GenerateAndDisplayCaptcha();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GenerateAndDisplayCaptcha();
        }

        private void GenerateAndDisplayCaptcha()
        {
            try
            {
                currentCaptcha = captchaImage.GenerateImage();
                pictureBox1.Image = Image.FromStream(new MemoryStream(currentCaptcha.ImageBytes));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao gerar CAPTCHA: {ex.Message}");
            }
        }
    }
}
