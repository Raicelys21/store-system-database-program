
namespace Sistema_Jugueteria_Chavodel8
{
    partial class Login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblog = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbusuario = new System.Windows.Forms.Label();
            this.lbcntrasena = new System.Windows.Forms.Label();
            this.tbusu = new System.Windows.Forms.TextBox();
            this.tbcontra = new System.Windows.Forms.TextBox();
            this.btncancel = new System.Windows.Forms.Button();
            this.btloguin = new System.Windows.Forms.Button();
            this.lbtruco = new System.Windows.Forms.Label();
            this.Logo1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.L_L_Frase = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Logo1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Sienna;
            this.panel2.Controls.Add(this.lblog);
            this.panel2.Location = new System.Drawing.Point(15, 197);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(322, 32);
            this.panel2.TabIndex = 15;
            // 
            // lblog
            // 
            this.lblog.AutoSize = true;
            this.lblog.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblog.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblog.Location = new System.Drawing.Point(88, 3);
            this.lblog.Name = "lblog";
            this.lblog.Size = new System.Drawing.Size(153, 22);
            this.lblog.TabIndex = 6;
            this.lblog.Text = "Inicio de Sesión";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbusuario);
            this.groupBox1.Controls.Add(this.lbcntrasena);
            this.groupBox1.Controls.Add(this.tbusu);
            this.groupBox1.Controls.Add(this.tbcontra);
            this.groupBox1.Location = new System.Drawing.Point(15, 243);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(322, 101);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // lbusuario
            // 
            this.lbusuario.AutoSize = true;
            this.lbusuario.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbusuario.Location = new System.Drawing.Point(18, 24);
            this.lbusuario.Name = "lbusuario";
            this.lbusuario.Size = new System.Drawing.Size(65, 16);
            this.lbusuario.TabIndex = 1;
            this.lbusuario.Text = "Usuario:";
            // 
            // lbcntrasena
            // 
            this.lbcntrasena.AutoSize = true;
            this.lbcntrasena.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbcntrasena.Location = new System.Drawing.Point(18, 60);
            this.lbcntrasena.Name = "lbcntrasena";
            this.lbcntrasena.Size = new System.Drawing.Size(89, 16);
            this.lbcntrasena.TabIndex = 2;
            this.lbcntrasena.Text = "Contraseña:";
            // 
            // tbusu
            // 
            this.tbusu.Location = new System.Drawing.Point(127, 23);
            this.tbusu.Name = "tbusu";
            this.tbusu.Size = new System.Drawing.Size(167, 20);
            this.tbusu.TabIndex = 0;
            this.tbusu.TextChanged += new System.EventHandler(this.tbusu_TextChanged);
            this.tbusu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbusu_KeyDown);
            // 
            // tbcontra
            // 
            this.tbcontra.Location = new System.Drawing.Point(127, 59);
            this.tbcontra.Name = "tbcontra";
            this.tbcontra.PasswordChar = '*';
            this.tbcontra.Size = new System.Drawing.Size(167, 20);
            this.tbcontra.TabIndex = 2;
            this.tbcontra.UseSystemPasswordChar = true;
            this.tbcontra.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbcontra_KeyPress);
            // 
            // btncancel
            // 
            this.btncancel.BackColor = System.Drawing.Color.Sienna;
            this.btncancel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncancel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btncancel.Location = new System.Drawing.Point(202, 358);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(98, 34);
            this.btncancel.TabIndex = 4;
            this.btncancel.Text = "Cancelar";
            this.btncancel.UseVisualStyleBackColor = false;
            this.btncancel.Click += new System.EventHandler(this.btncancel_Click);
            // 
            // btloguin
            // 
            this.btloguin.BackColor = System.Drawing.Color.Sienna;
            this.btloguin.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btloguin.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btloguin.Location = new System.Drawing.Point(57, 358);
            this.btloguin.Name = "btloguin";
            this.btloguin.Size = new System.Drawing.Size(98, 34);
            this.btloguin.TabIndex = 3;
            this.btloguin.Text = "Acceder";
            this.btloguin.UseVisualStyleBackColor = false;
            this.btloguin.Click += new System.EventHandler(this.btloguin_Click);
            // 
            // lbtruco
            // 
            this.lbtruco.AutoSize = true;
            this.lbtruco.Location = new System.Drawing.Point(73, 375);
            this.lbtruco.Name = "lbtruco";
            this.lbtruco.Size = new System.Drawing.Size(0, 13);
            this.lbtruco.TabIndex = 16;
            // 
            // Logo1
            // 
            this.Logo1.Image = global::Sistema_Jugueteria_Chavodel8.Properties.Resources.ChavoDel8;
            this.Logo1.Location = new System.Drawing.Point(122, 10);
            this.Logo1.Margin = new System.Windows.Forms.Padding(2);
            this.Logo1.Name = "Logo1";
            this.Logo1.Size = new System.Drawing.Size(104, 104);
            this.Logo1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Logo1.TabIndex = 7;
            this.Logo1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Snow;
            this.panel1.BackgroundImage = global::Sistema_Jugueteria_Chavodel8.Properties.Resources.Background1;
            this.panel1.Location = new System.Drawing.Point(-2, -3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(360, 137);
            this.panel1.TabIndex = 17;
            // 
            // L_L_Frase
            // 
            this.L_L_Frase.AutoSize = true;
            this.L_L_Frase.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_L_Frase.Location = new System.Drawing.Point(8, 156);
            this.L_L_Frase.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.L_L_Frase.Name = "L_L_Frase";
            this.L_L_Frase.Size = new System.Drawing.Size(340, 18);
            this.L_L_Frase.TabIndex = 18;
            this.L_L_Frase.Text = "¡Llevando felicidad a cada rincón del país!";
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 413);
            this.Controls.Add(this.L_L_Frase);
            this.Controls.Add(this.Logo1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btncancel);
            this.Controls.Add(this.btloguin);
            this.Controls.Add(this.lbtruco);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximumSize = new System.Drawing.Size(368, 452);
            this.MinimumSize = new System.Drawing.Size(368, 452);
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Login_FormClosing);
            this.Load += new System.EventHandler(this.Login_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Logo1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblog;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbusuario;
        private System.Windows.Forms.Label lbcntrasena;
        private System.Windows.Forms.TextBox tbusu;
        private System.Windows.Forms.TextBox tbcontra;
        private System.Windows.Forms.Button btncancel;
        private System.Windows.Forms.Button btloguin;
        public System.Windows.Forms.Label lbtruco;
        private System.Windows.Forms.PictureBox Logo1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label L_L_Frase;
    }
}

