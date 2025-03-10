﻿using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PictureReSize
{
    public partial class UpdateHistoryWindow : Form
    {
        readonly string UpdateHistoryURL = @"https://kosenyaxs.stars.ne.jp/PictureResize/UpdateHistory.txt";

        private static readonly HttpClient client = new();

        public UpdateHistoryWindow()
        {
            InitializeComponent();
        }

        private async void UpdateHistoryWindow_Load(object sender, EventArgs e)
        {
            // 更新履歴の取得と表示
            string updateHistory = await GetUpdateHistoryAsync();
            this.info_richTextBox.Text = updateHistory;
        }

        private async Task<string> GetUpdateHistoryAsync()
        {
            try
            {
                var getUpdateHistory = await client.GetStringAsync(UpdateHistoryURL);

                return getUpdateHistory;
            }
            catch (Exception e)
            {
                return $"更新履歴の取得に失敗しました。{Environment.NewLine} {e.Message}";
            }
        }

        private void ok_button_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

    }
}
