namespace Kursach
{
	partial class Form1
	{
		/// <summary>
		/// Обязательная переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.InfoLabel = new System.Windows.Forms.Label();
			this.TurnButton = new System.Windows.Forms.Button();
			this.StartStopButton = new System.Windows.Forms.Button();
			this.RestartButton = new System.Windows.Forms.Button();
			this.TurningTimer = new System.Windows.Forms.Timer(this.components);
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.SettingsButton = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.SettingsButton)).BeginInit();
			this.SuspendLayout();
			// 
			// InfoLabel
			// 
			this.InfoLabel.AutoSize = true;
			this.InfoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.InfoLabel.Location = new System.Drawing.Point(224, 914);
			this.InfoLabel.Name = "InfoLabel";
			this.InfoLabel.Size = new System.Drawing.Size(0, 18);
			this.InfoLabel.TabIndex = 0;
			// 
			// TurnButton
			// 
			this.TurnButton.Location = new System.Drawing.Point(808, 937);
			this.TurnButton.Name = "TurnButton";
			this.TurnButton.Size = new System.Drawing.Size(100, 35);
			this.TurnButton.TabIndex = 2;
			this.TurnButton.Text = "Ход";
			this.TurnButton.UseVisualStyleBackColor = true;
			this.TurnButton.Click += new System.EventHandler(this.TurnButton_Click);
			// 
			// StartStopButton
			// 
			this.StartStopButton.Location = new System.Drawing.Point(978, 937);
			this.StartStopButton.Name = "StartStopButton";
			this.StartStopButton.Size = new System.Drawing.Size(100, 35);
			this.StartStopButton.TabIndex = 6;
			this.StartStopButton.Text = "Старт/Стоп";
			this.StartStopButton.UseVisualStyleBackColor = true;
			this.StartStopButton.Click += new System.EventHandler(this.StartStopButton_Click);
			// 
			// RestartButton
			// 
			this.RestartButton.Location = new System.Drawing.Point(1148, 937);
			this.RestartButton.Name = "RestartButton";
			this.RestartButton.Size = new System.Drawing.Size(100, 35);
			this.RestartButton.TabIndex = 7;
			this.RestartButton.Text = "Заново";
			this.RestartButton.UseVisualStyleBackColor = true;
			this.RestartButton.Click += new System.EventHandler(this.RestartButton_Click);
			// 
			// TurningTimer
			// 
			this.TurningTimer.Interval = 500;
			this.TurningTimer.Tick += new System.EventHandler(this.TurningTimer_Tick);
			// 
			// SettingsButton
			// 
			this.SettingsButton.BackColor = System.Drawing.SystemColors.ControlLight;
			this.SettingsButton.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.SettingsButton.Image = global::Kursach.Properties.Resources.settings;
			this.SettingsButton.Location = new System.Drawing.Point(1776, 929);
			this.SettingsButton.Name = "SettingsButton";
			this.SettingsButton.Size = new System.Drawing.Size(50, 50);
			this.SettingsButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.SettingsButton.TabIndex = 9;
			this.SettingsButton.TabStop = false;
			this.SettingsButton.Click += new System.EventHandler(this.SettingsButton_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1916, 1047);
			this.Controls.Add(this.SettingsButton);
			this.Controls.Add(this.RestartButton);
			this.Controls.Add(this.StartStopButton);
			this.Controls.Add(this.TurnButton);
			this.Controls.Add(this.InfoLabel);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Form1";
			this.Text = "Игра «Волчий остров»";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			((System.ComponentModel.ISupportInitialize)(this.SettingsButton)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label InfoLabel;
		private System.Windows.Forms.Button TurnButton;
		private System.Windows.Forms.Button StartStopButton;
		private System.Windows.Forms.Button RestartButton;
		private System.Windows.Forms.Timer TurningTimer;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.PictureBox SettingsButton;
	}
}

