using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;
using DevExpress.LookAndFeel;
using DevExpress.Skins;

namespace TeknikServis
{
    public partial class FrmTema : Kalitim
    {
        public FrmTema()
        {
            InitializeComponent();
        }

        #region Tema Seçici
        private void FrmTema_Load(object sender, EventArgs e)
        {
            cmbTema.SelectedIndexChanged += CmbTema_SelectedIndexChanged;
            foreach (SkinContainer item in SkinManager.Default.Skins)
            {
                cmbTema.Properties.Items.Add(item.SkinName);
            }
        }

        private void CmbTema_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBoxEdit comboBox = sender as ComboBoxEdit;
            string skinAdi = comboBox.Text;
            UserLookAndFeel.Default.SkinName = skinAdi;
        }
        #endregion


        #region Uygula Butonu
        private void btnUygula_Click(object sender, EventArgs e)
        {
            using (StreamWriter sw = new StreamWriter("kartel_themes.ltd"))
            {
                sw.WriteLine(cmbTema.Text);
                MessageBoxes.Information("Tema Kaydedildi");
                this.Close();
            }
        } 
        #endregion

    }
}