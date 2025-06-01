using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using SolidEdgeFramework;
using SolidEdgePart;
using SolidEdgeGeometry;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private SolidEdgeFramework.Application seApp;
        private SolidEdgePart.PartDocument sePartDoc;
        private SolidEdgeGeometry.Faces faces;
        private SolidEdgeFramework.FaceStyles faceStyles;


        public Form1()
        {
            InitializeComponent();
            this.btnClose.Click += new EventHandler(this.btnClose_Click);
            this.btnRefresh.Click += new EventHandler(this.btnRefresh_Click);
            this.Resize += (s, e) => On_size_Changed();
            this.listViewFaces.SelectedIndexChanged += new EventHandler(this.listViewFaces_SelectedIndexChanged);

        }
        private void ConnectToSolidEdge()
        {
            try
            {
                seApp = (SolidEdgeFramework.Application)Marshal.GetActiveObject("SolidEdge.Application");

                if (seApp.ActiveDocumentType != SolidEdgeFramework.DocumentTypeConstants.igPartDocument)
                {
                    throw new Exception("Откройте Part-документ в Solid Edge.");
                }

                sePartDoc = (PartDocument)seApp.ActiveDocument;
                faceStyles = (FaceStyles)sePartDoc.FaceStyles;
                var model = sePartDoc.Models.Item(1);
                var body = (SolidEdgeGeometry.Body)model.Body;
                faces = (Faces)body.Faces[SolidEdgeGeometry.FeatureTopologyQueryTypeConstants.igQueryAll];
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка подключения к Solid Edge: {ex.Message}");
                this.Close();
            }
        }

        private void LoadFacesToList()
        {
            listViewFaces.View = System.Windows.Forms.View.Details;
            listViewFaces.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
            listViewFaces.Columns.Clear();
            listViewFaces.Columns.Add("Список граней", listViewFaces.Width);
            listViewFaces.Items.Clear();

            for (int i = 1; i <= faces.Count; i++)
            {
                var face = (Face)faces.Item(i);
                var item = new ListViewItem($"Грань {i}") { Tag = i };
                listViewFaces.Items.Add(item);
            }
        }

        private void listViewFaces_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var selectSet = seApp.ActiveSelectSet;
                selectSet.RemoveAll();

                foreach (ListViewItem item in listViewFaces.SelectedItems)
                {
                    try
                    {
                        int faceIndex = (int)item.Tag;
                        Face face = (Face)faces.Item(faceIndex);
                        selectSet.Add(face);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при выделении грани: {ex.Message}");
                    }
                }
                seApp.DoIdle();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при подсветке грани: {ex.Message}");
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ConnectToSolidEdge();
            LoadFacesToList();
            panelColors_Paint();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void add_color(FaceStyle selectedStyle)
        {
            sePartDoc = (PartDocument)seApp.ActiveDocument;
            var selectedFaces = seApp.ActiveSelectSet;

            for (int i = 1; i <= selectedFaces.Count; i++)
            {
                SolidEdgeGeometry.Face face = (Face)selectedFaces.Item(i);
                face.Style = selectedStyle;
            }
        }

        private void panelColors_Paint()
        {
            try
            {
                panelColors.Controls.Clear();

                if (faceStyles == null || faceStyles.Count == 0) return;

                int y = 10;

                for (int i = 1; i <= faceStyles.Count; i++)
                {
                    FaceStyle style = (FaceStyle)faceStyles.Item(i);
                    Button btn = new Button()
                    {
                        Width = panelColors.Width - 40,
                        Height = 30,
                        BackColor = Color.White,
                        Location = new Point(10, y),
                        Font = new Font("Segoe UI", 11F, FontStyle.Regular),
                        Tag = style,
                        Text = style.StyleName,
                        FlatStyle = FlatStyle.Flat
                    };

                    btn.Click += (s, a) =>
                    {
                        FaceStyle selectedStyle = (FaceStyle)((Button)s).Tag;
                        add_color(selectedStyle);
                    };

                    panelColors.Controls.Add(btn);
                    y += 35;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка отображения FaceStyles: {ex.Message}");
            }
        }

        private void On_size_Changed()
        {
            int padding = 20;
            int buttonWidth = 90;
            int buttonHeight = 30;

            // Высота области для списка и панели
            int contentHeight = this.ClientSize.Height - buttonHeight - padding * 3;

            // Ширина колонок (поровну)
            int columnWidth = (this.ClientSize.Width - padding * 3) / 2;

            // ==== ListView (слева) ====
            listViewFaces.Left = padding;
            listViewFaces.Top = padding;
            listViewFaces.Width = columnWidth;
            listViewFaces.Height = contentHeight;

            // ==== Panel (справа) ====
            panelColors.Left = listViewFaces.Right + padding;
            panelColors.Top = padding;
            panelColors.Width = columnWidth;
            panelColors.Height = contentHeight;

            // ==== Кнопки ====
            btnRefresh.Width = btnClose.Width = buttonWidth;
            btnRefresh.Height = btnClose.Height = buttonHeight;
            btnRefresh.Left = listViewFaces.Left;
            btnRefresh.Font = btnClose.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
            btnRefresh.Top = btnClose.Top = listViewFaces.Bottom + padding;
            btnClose.Left = panelColors.Right - buttonWidth;
        }
    }
}


