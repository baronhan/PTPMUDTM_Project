using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DTO;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;

namespace HotelBooking
{
    public partial class Form_Payment : Form
    {
        private string endpoint = "https://test-payment.momo.vn/v2/gateway/api/create";
        private string partnerCode = "MOMO5RGX20191128";
        private string accessKey = "M8brj9K6E22vXoDB";
        private string serectkey = "nqQiVSgDMy809JoPF6OzP5OdBUB550Y4";
        private string order_id;
        private decimal totalPrice = 0;

        private Form_Main formMain;
        private List<Dich_VuDTO> list;
        private PhieuDatPhongDTO pdp;

        public Form_Payment(Form_Main formMain, List<Dich_VuDTO> list, PhieuDatPhongDTO pdp)
        {
            InitializeComponent();
            this.formMain = formMain;
            this.list = list;
            this.pdp = pdp;

            if (pdp != null)
            {
                createMomoCode(pdp.tongTien);
            }
        }

        private void createMomoCode(decimal total)
        {
            // Thông tin giao dịch
            string orderInfo = "TEST";
            string redirectUrl = "https://webhook.site/b3088a6a-2d17-4f8d-a383-71389a6c600b";
            string requestId = Guid.NewGuid().ToString();
            string orderId = Guid.NewGuid().ToString();
            order_id = orderId;

            // Tạo chữ ký
            string rawHash = GenerateRawHash(orderId, orderInfo, redirectUrl, requestId, total);
            //string signature = new MoMoSecurity().signSHA256(rawHash, serectkey);

            // Build the JSON request
            //JObject message = BuildJsonRequest(orderId, orderInfo, redirectUrl, requestId, signature, total);

            // Use await to call the asynchronous method
            //string responseFromMomo = await PaymentRequest.sendPaymentRequest(endpoint, message.ToString());

            // Xử lý phản hồi
            //HandlePaymentResponse(responseFromMomo);
        }

        private string GenerateRawHash(string orderId, string orderInfo, string redirectUrl, string requestId, decimal total)
        {
            return $"accessKey={accessKey}&amount={total}&extraData=&ipnUrl=https://webhook.site/b3088a6a-2d17-4f8d-a383-71389a6c600b&orderId={orderId}&orderInfo={orderInfo}&partnerCode={partnerCode}&redirectUrl={redirectUrl}&requestId={requestId}&requestType=captureWallet";
        }

        private JObject BuildJsonRequest(string orderId, string orderInfo, string redirectUrl, string requestId, string signature, decimal total)
        {
            return new JObject
            {
                { "partnerCode", partnerCode },
                { "partnerName", "Test" },
                { "storeId", "MomoTestStore" },
                { "requestId", requestId },
                { "amount", total },
                { "orderId", orderId },
                { "orderInfo", orderInfo },
                { "redirectUrl", redirectUrl },
                { "ipnUrl", "https://webhook.site/b3088a6a-2d17-4f8d-a383-71389a6c600b" },
                { "lang", "en" },
                { "extraData", "" },
                { "requestType", "captureWallet" },
                { "signature", signature }
            };
        }

        private void HandlePaymentResponse(string responseFromMomo)
        {
            JObject jmessage = JObject.Parse(responseFromMomo);
            DialogResult result = MessageBox.Show("Ấn OK để tới trang thanh toán", "Thông báo", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                System.Diagnostics.Process.Start(jmessage.GetValue("payUrl").ToString());
            }
        }

        private void btnCancelPayment_Click(object sender, EventArgs e)
        {
            if (ConfirmCancel())
            {
                NavigateToHome();
            }
        }

        private bool ConfirmCancel()
        {
            return MessageBox.Show("Bạn có chắc chắn muốn hủy giao dịch không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        private void NavigateToHome()
        {
            Form_Home form = new Form_Home();
            formMain.AddControls(form);
            form.Show();
        }

        private void btnReturnServiceList_Click(object sender, EventArgs e)
        {
            if (pdp != null)
            {
                Form_PhieuDatPhong form = new Form_PhieuDatPhong(formMain, list, pdp.maPhong);
                formMain.AddControls(form);
                form.Show();
            }
        }
    }
}
