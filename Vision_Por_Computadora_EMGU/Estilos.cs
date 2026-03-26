using System;
using System.Collections.Generic;
using System.Text;

namespace Vision_Por_Computadora_EMGU
{
    public class Estilos
    {
        public static Color Fondo = Color.FromArgb(30, 30, 46);
        public static Color Superficie = Color.FromArgb(45, 45, 65);
        public static Color Acento = Color.FromArgb(137, 180, 250);
        public static Color AcentoHover = Color.FromArgb(116, 199, 236);
        public static Color Peligro = Color.FromArgb(243, 139, 168);
        public static Color PeligroHover = Color.FromArgb(235, 111, 146);
        public static Color TextoClaro = Color.White;
        public static Color TextoOscuro = Color.FromArgb(30, 30, 46);
        public static Color TextoSecundario = Color.FromArgb(166, 173, 200);
        public static Color CeldaAlterna = Color.FromArgb(40, 40, 58);
        public static Font FuenteNormal = new("Segoe UI", 14);
        public static Font FuenteBold = new("Segoe UI", 14, FontStyle.Bold);
        public static Font FuenteTitulo = new("Segoe UI", 24, FontStyle.Bold);
        public static void EstilizarForm(Form frm, string titulo)
        {
            frm.BackColor = Fondo;
            frm.Text = titulo;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.MaximizeBox = false;
            frm.Font = FuenteNormal;
        }
        public static void EstilizarBoton(Button btn, string texto, bool esPeligro = false)
        {
            Color color = esPeligro ? Peligro : Acento;
            Color hover = esPeligro ? PeligroHover : AcentoHover;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = color;
            btn.ForeColor = TextoOscuro;
            btn.Font = FuenteBold;
            btn.Text = texto;
            btn.Cursor = Cursors.Hand;
            btn.MouseEnter += (s, e) => btn.BackColor = hover;
            btn.MouseLeave += (s, e) => btn.BackColor = color;
        }
        public static void EstilizarTextBox(TextBox tb)
        {
            tb.BackColor = Superficie;
            tb.ForeColor = TextoClaro;
            tb.Font = FuenteNormal;
            tb.BorderStyle = BorderStyle.FixedSingle;
            tb.Enter += (s, e) => tb.BackColor = Color.FromArgb(55, 55, 80);
            tb.Leave += (s, e) => tb.BackColor = Superficie;
        }
        public static void EstilizarTextBoxConPlaceholder(TextBox tb, string placeholder)
        {
            EstilizarTextBox(tb);
            tb.Text = placeholder;
            tb.ForeColor = TextoSecundario;
            tb.Enter += (s, e) => {
                if (tb.Text == placeholder) { tb.Text = ""; tb.ForeColor = TextoClaro; }
            };
            tb.Leave += (s, e) => {
                if (string.IsNullOrWhiteSpace(tb.Text)) { tb.Text = placeholder; tb.ForeColor = TextoSecundario; }
            };
        }
        public static void EstilizarDataGridView(DataGridView dgv)
        {
            dgv.BorderStyle = BorderStyle.None;
            dgv.BackgroundColor = Fondo;
            dgv.GridColor = Superficie;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Acento;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = TextoOscuro;
            dgv.ColumnHeadersDefaultCellStyle.Font = FuenteBold;
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = Acento;
            dgv.ColumnHeadersHeight = 40;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv.DefaultCellStyle.BackColor = Fondo;
            dgv.DefaultCellStyle.ForeColor = TextoClaro;
            dgv.DefaultCellStyle.Font = FuenteNormal;
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(60, 60, 90);
            dgv.DefaultCellStyle.SelectionForeColor = TextoClaro;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = CeldaAlterna;
            dgv.AlternatingRowsDefaultCellStyle.ForeColor = TextoClaro;
            dgv.RowHeadersVisible = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.RowTemplate.Height = 35;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AllowUserToAddRows = false;
            dgv.ReadOnly = true;
        }
        public static void EstilizarPictureBox(PictureBox pb)
        {
            pb.BackColor = Superficie;
            pb.SizeMode = PictureBoxSizeMode.Zoom;
            pb.BorderStyle = BorderStyle.None;
            pb.Paint += (s, e) => {
                using (Pen pen = new(Acento, 2))
                    e.Graphics.DrawRectangle(pen, 0, 0, pb.Width - 1, pb.Height - 1);
                if (pb.Image == null)
                {
                    string txt = "📷 Sin imagen";
                    SizeF sz = e.Graphics.MeasureString(txt, FuenteNormal);
                    using Brush b = new SolidBrush(TextoSecundario);
                    e.Graphics.DrawString(txt, FuenteNormal, b, (pb.Width - sz.Width) / 2, (pb.Height - sz.Height) / 2);
                }
            };
        }

        public static void EstilizarComboBox(ComboBox cb)
        {
            cb.BackColor = Superficie;
            cb.ForeColor = TextoClaro;
            cb.Font = FuenteNormal;
            cb.FlatStyle = FlatStyle.Flat;
            cb.DropDownStyle = ComboBoxStyle.DropDownList;
            cb.DrawMode = DrawMode.OwnerDrawFixed;
            cb.ItemHeight = 30;
            cb.DrawItem += (s, e) => {
                if (e.Index < 0) return;
                bool sel = (e.State & DrawItemState.Selected) != 0;
                using Brush fb = new SolidBrush(sel ? Acento : Superficie);
                using Brush tb = new SolidBrush(sel ? TextoOscuro : TextoClaro);
                e.Graphics.FillRectangle(fb, e.Bounds);
                e.Graphics.DrawString(cb.Items[e.Index].ToString(), FuenteNormal, tb, e.Bounds.X + 8, e.Bounds.Y + 5);
            };
        }
        public static void EstilizarLabel(Label lbl, bool esTitulo = false)
        {
            lbl.ForeColor = TextoClaro;
            lbl.Font = esTitulo ? FuenteTitulo : FuenteBold;
            lbl.BackColor = Color.Transparent;
        }
        public static void EstilizarTabControl(TabControl tc)
        {
            tc.DrawMode = TabDrawMode.OwnerDrawFixed;
            tc.SizeMode = TabSizeMode.Fixed;
            tc.ItemSize = new Size(150, 40);
            tc.Font = FuenteBold;
            tc.Appearance = TabAppearance.FlatButtons;
            tc.BackColor = Fondo;

            foreach (TabPage tab in tc.TabPages)
            {
                tab.BackColor = Fondo;
                tab.ForeColor = TextoClaro;
                tab.BorderStyle = BorderStyle.None;
            }

            tc.DrawItem += (sender, e) =>
            {
                TabControl tabCtrl = (TabControl)sender;
                TabPage page = tabCtrl.TabPages[e.Index];
                bool seleccionada = (e.Index == tabCtrl.SelectedIndex);

                Color fondoTab = seleccionada ? Acento : Superficie;
                Color textoTab = seleccionada ? TextoOscuro : TextoClaro;

                using (Brush fondoBrush = new SolidBrush(fondoTab))
                {
                    e.Graphics.FillRectangle(fondoBrush, e.Bounds);
                }

                if (seleccionada)
                {
                    using Pen pen = new(Acento, 3);
                    e.Graphics.DrawLine(pen,
                        e.Bounds.Left, e.Bounds.Bottom - 2,
                        e.Bounds.Right, e.Bounds.Bottom - 2);
                }

                TextRenderer.DrawText(
                    e.Graphics,
                    page.Text,
                    seleccionada ? FuenteBold : FuenteNormal,
                    e.Bounds,
                    textoTab,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter
                );
            };
        }
        public static void EstilizarCheckBox(CheckBox cb)
        {
            cb.ForeColor = TextoClaro;
            cb.BackColor = Fondo;
            cb.Font = FuenteNormal;
            cb.Cursor = Cursors.Hand;
            cb.FlatStyle = FlatStyle.Standard;
            cb.Padding = new Padding(3, 2, 3, 2);
        }
    }
}
