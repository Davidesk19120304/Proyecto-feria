using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace WindowsFormsApp1
{
    public partial class Form5 : Form
    { 
       private Button currentButton;
    private Random random;
    private int tempIndex;
    private Form activeForm;
    
        public Form5()
    {
            InitializeComponent();
            random = new Random();
            
        

    }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private Color SelectThemeColor ()
    {
        int index = random.Next(Class1.ColorList.Count);
        while (tempIndex == index)
        {
            index = random.Next(Class1.ColorList.Count);
        }
        tempIndex = index;
        string color = Class1.ColorList[index];
        return ColorTranslator.FromHtml(color);

    }
        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    Color color = SelectThemeColor();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;

                  currentButton.Font = new System.Drawing.Font("Century Gothic ", 13.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    panel1.BackColor = color;
                    panel3.BackColor = Class1.ChangeColorBrightness(color, -0.3);
                   
                }
            }

        }
        private void DisableButton()
        {
            foreach (Control previousBtn in panel1.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(51, 51, 76);
                    previousBtn.ForeColor = Color.WhiteSmoke;
                    previousBtn.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }
        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
                activeForm.Close();
            ActivateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelescritorio.Controls.Add(childForm);
            this.panelescritorio.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            label1.Text = childForm.Text;
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenChildForm(new Formularios.Juegos(), sender);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenChildForm(new Formularios.Mùsica(), sender);
        }

        private void lineShape1_Click(object sender, EventArgs e)
        {

        }


        private void button7_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            Form4 form4 = new Form4();
            form4.Show(this);
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenChildForm(new Formularios.profe(), sender);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenChildForm(new Formularios.comunicate(), sender);
        }

        private void bindingNavigator1_RefreshItems(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenChildForm(new Formularios.Amigos(), sender);


        }

        private void Form5_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panelescritorio_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2ShadowPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void panelescritorio_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }
    }
}
