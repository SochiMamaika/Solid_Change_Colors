
namespace WindowsFormsApp1
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
            this.listViewFaces = new System.Windows.Forms.ListView();
            this.panelColors = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listViewFaces
            // 
            this.listViewFaces.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewFaces.FullRowSelect = true;
            this.listViewFaces.GridLines = true;
            this.listViewFaces.HideSelection = false;
            this.listViewFaces.Location = new System.Drawing.Point(26, 22);
            this.listViewFaces.Name = "listViewFaces";
            this.listViewFaces.Size = new System.Drawing.Size(362, 348);
            this.listViewFaces.TabIndex = 0;
            this.listViewFaces.UseCompatibleStateImageBehavior = false;
            this.listViewFaces.View = System.Windows.Forms.View.Details;
            // 
            // panelColors
            // 
            this.panelColors.AutoScroll = true;
            this.panelColors.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelColors.Location = new System.Drawing.Point(412, 22);
            this.panelColors.Name = "panelColors";
            this.panelColors.Size = new System.Drawing.Size(362, 348);
            this.panelColors.TabIndex = 1;
            // 
            // btnRefresh
            // 
            this.btnRefresh.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Location = new System.Drawing.Point(699, 395);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Обновить";
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(26, 395);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Закрыть";
            // 
            // Form1
            // 
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listViewFaces);
            this.Controls.Add(this.panelColors);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnClose);
            this.MinimumSize = new System.Drawing.Size(350, 350);
            this.Name = "Form1";
            this.Text = "Установка цвета";
            this.ResumeLayout(false);
            On_size_Changed();
        }


        #endregion

        private System.Windows.Forms.ListView listViewFaces;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panelColors;
    }
}

