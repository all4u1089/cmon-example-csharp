using System;
using System.Collections.Generic;
using IO.Swagger.Client;
using IO.Swagger.org.wso2.client.api.Cmon;
using IO.Swagger.org.wso2.client.model.Cmon;

namespace cmon_example
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            string adapterAddress = "https://api.lgsp.quangnam.gov.vn:8247";
            string key = "5nl1mqdYdNhZACbyAvydq9JzSloa"; // (1) Consumer key
            string secret = "StuEwUaidp2t4CQCNCSDjmlTeWsa"; // (2) Consumer secret
            string url = adapterAddress + "/token"; // (3) URL get token
            ToKenResponse token = new AccessTokenJson(key, secret, url).GetToken().Result;

            if (token == null)
            {
                return;
            }

            Console.WriteLine("Access Token: " + token.AccessToken);
            
            ApiClient defaultClient = new ApiClient(adapterAddress + "/cmon/v1.0.0");
            defaultClient.Configuration.AddDefaultHeader("Authorization", "Bearer " + token.AccessToken);

            int run = 1;

            //1: Lấy danh sách cấp cơ quan quản lý
            //2: Lấy cấp cơ quan quản lý theo mã
            //3: Lấy danh sách đơn vị hành chính theo cấp (TINH, HUYEN, XA)
            //4: Lấy danh sách đơn vị hành chính theo cấp trên
            //5: Lấy đơn vị hành chính theo mã
            //6: Lấy danh sách cơ quan quản lý theo mã cấp cơ quan quản lý
            //7: Lấy danh sách cơ quan quản lý theo mã cơ quan quản lý cấp trên
            //8: Lấy cơ quan quản lý theo mã cơ quan quản lý
            //9: Lấy danh sách dân tộc
            //10: Lấy dân tộc theo ID
            //11: Lấy danh sách tôn giáo
            //12: Lấy tôn giáo theo ID
            //13: Lấy danh sách loại đơn vị đo lường
            //14: Lấy loại đơn vị đo lường theo ID
            //15: Lấy danh sách đơn vị đo lường
            //16: Lấy đơn vị đo lường theo ID

            CapcoquanquanlysApi apiInstanceCapCoQuanQuanLy = new CapcoquanquanlysApi();
            apiInstanceCapCoQuanQuanLy.Configuration.setApiClientUsingDefault(defaultClient);

            switch (run)
            {
                case 1:      
                    try
                    {
                        // Lấy danh sách cấp cơ quan quản lý
                        List<CapCoQuanQuanLy> listCapCoQuanQuanLy = apiInstanceCapCoQuanQuanLy.CapcoquanquanlysGet();
                        foreach (var capCQQL in listCapCoQuanQuanLy)
                        {
                            Console.WriteLine("---------------------");
                            Console.WriteLine("id: " + capCQQL.Id);
                            Console.WriteLine("ma: " + capCQQL.Ma);
                            Console.WriteLine("ten: " + capCQQL.Ten);
                            Console.WriteLine("cap: " + capCQQL.Cap);
                            Console.WriteLine("capTren: " + capCQQL.CapTren);
                        }

                    }
                    catch (ApiException e)
                    {
                        
                    }
                    break;
                case 2:
                    // Lấy cấp cơ quan quản lý theo mã
                    try
                    {
                        CapCoQuanQuanLy capCQQL = apiInstanceCapCoQuanQuanLy.CapcoquanquanlysMaGet("002");
                        if (capCQQL != null)
                        {
                            Console.WriteLine("id: " + capCQQL.Id);
                            Console.WriteLine("ma: " + capCQQL.Ma);
                            Console.WriteLine("ten: " + capCQQL.Ten);
                            Console.WriteLine("cap: " + capCQQL.Cap);
                            Console.WriteLine("capTren: " + capCQQL.CapTren);
                        }
                    }
                    catch (ApiException e)
                    {
                        
                    }
                    break;
                case 3:
                    // Lấy danh sách đơn vị hành chính theo cấp (TINH, HUYEN, XA)
                    DonvihanhchinhsApi apiDonViHanhChinh = new DonvihanhchinhsApi();
                    apiDonViHanhChinh.Configuration.setApiClientUsingDefault(defaultClient);
                    try
                    {
                        List<DonViHanhChinh> listDVHC = apiDonViHanhChinh.DonvihanhchinhsCapCapGet("TINH");
                        foreach (var dvhc in listDVHC)
                        {
                            Console.WriteLine("---------------------");
                            Console.WriteLine("id: " + dvhc.Id);
                            Console.WriteLine("ma: " + dvhc.Ma);
                            Console.WriteLine("ten: " + dvhc.Ten);
                            Console.WriteLine("tenTA: " + dvhc.TenTA);
                            Console.WriteLine("cap: " + dvhc.Cap);
                            Console.WriteLine("capTren: " + dvhc.CapTren);
                        }
                    }
                    catch (ApiException e)
                    {
                        
                    }
                    break;
                case 4:
                    // Lấy danh sách đơn vị hành chính theo cấp trên
                    DonvihanhchinhsApi apiDonViHanhChinh2 = new DonvihanhchinhsApi();
                    apiDonViHanhChinh2.Configuration.setApiClientUsingDefault(defaultClient);
                    try
                    {
                        List<DonViHanhChinh> listDVHC = apiDonViHanhChinh2.DonvihanhchinhsCapTrenCapTrenGet("49");
                        foreach (DonViHanhChinh dvhc in listDVHC)
                        {
                            Console.WriteLine("---------------------");
                            Console.WriteLine("id: " + dvhc.Id);
                            Console.WriteLine("ma: " + dvhc.Ma);
                            Console.WriteLine("ten: " + dvhc.Ten);
                            Console.WriteLine("tenTA: " + dvhc.TenTA);
                            Console.WriteLine("cap: " + dvhc.Cap);
                            Console.WriteLine("capTren: " + dvhc.CapTren);
                        }
                    }
                    catch (ApiException e)
                    {
                        
                    }
                    break;
                case 5:
                    // Lấy đơn vị hành chính theo mã
                    DonvihanhchinhsApi apiDonViHanhChinh3 = new DonvihanhchinhsApi();
                    apiDonViHanhChinh3.Configuration.setApiClientUsingDefault(defaultClient);
                    try
                    {
                        DonViHanhChinh dvhc = apiDonViHanhChinh3.DonvihanhchinhsMaGet("49");
                        if (dvhc != null)
                        {
                            Console.WriteLine("id: " + dvhc.Id);
                            Console.WriteLine("ma: " + dvhc.Ma);
                            Console.WriteLine("ten: " + dvhc.Ten);
                            Console.WriteLine("tenTA: " + dvhc.TenTA);
                            Console.WriteLine("cap: " + dvhc.Cap);
                            Console.WriteLine("capTren: " + dvhc.CapTren);
                        }
                    }
                    catch (ApiException e)
                    {
                        
                    }
                    break;
                case 6:
                    // Lấy danh sách cơ quan quản lý theo mã cấp cơ quan quản lý
                    CoquanquanlysApi apiCoQuanQuanLy = new CoquanquanlysApi();
                    apiCoQuanQuanLy.Configuration.setApiClientUsingDefault(defaultClient);
                    try
                    {
                        List<CoQuanQuanLy> listCQQL = apiCoQuanQuanLy.CoquanquanlysCapCapGet("002");
                        foreach (CoQuanQuanLy cqql in listCQQL)
                        {
                            Console.WriteLine("---------------------");
                            Console.WriteLine("id: " + cqql.Id);
                            Console.WriteLine("ma: " + cqql.Ma);
                            Console.WriteLine("ten: " + cqql.Ten);
                            Console.WriteLine("diaChi: " + cqql.DiaChi);
                            Console.WriteLine("dienThoai: " + cqql.DienThoai);
                            Console.WriteLine("email: " + cqql.Email);
                            Console.WriteLine("fax: " + cqql.Fax);
                            Console.WriteLine("website: " + cqql.Website);
                            Console.WriteLine("cap: " + cqql.Cap);
                            Console.WriteLine("capTren: " + cqql.CapTren);
                            Console.WriteLine("donViHanhChinh: " + cqql.DonViHanhChinh);
                        }
                    }
                    catch (ApiException e)
                    {
                        
                    }
                    break;
                case 7:
                    // Lấy danh sách cơ quan quản lý theo mã cơ quan quản lý cấp trên
                    CoquanquanlysApi apiCoQuanQuanLy2 = new CoquanquanlysApi();
                    apiCoQuanQuanLy2.Configuration.setApiClientUsingDefault(defaultClient);
                    try
                    {
                        List<CoQuanQuanLy> listCQQL = apiCoQuanQuanLy2.CoquanquanlysCapTrenCapTrenGet("00001");
                        foreach (CoQuanQuanLy cqql in listCQQL)
                        {
                            Console.WriteLine("---------------------");
                            Console.WriteLine("id: " + cqql.Id);
                            Console.WriteLine("ma: " + cqql.Ma);
                            Console.WriteLine("ten: " + cqql.Ten);
                            Console.WriteLine("diaChi: " + cqql.DiaChi);
                            Console.WriteLine("dienThoai: " + cqql.DienThoai);
                            Console.WriteLine("email: " + cqql.Email);
                            Console.WriteLine("fax: " + cqql.Fax);
                            Console.WriteLine("website: " + cqql.Website);
                            Console.WriteLine("cap: " + cqql.Cap);
                            Console.WriteLine("capTren: " + cqql.CapTren);
                            Console.WriteLine("donViHanhChinh: " + cqql.DonViHanhChinh);
                        }
                    }
                    catch (ApiException e)
                    {
                        
                    }
                    break;
                case 8:
                    // Lấy cơ quan quản lý theo mã cơ quan quản lý
                    CoquanquanlysApi apiCoQuanQuanLy3 = new CoquanquanlysApi();
                    apiCoQuanQuanLy3.Configuration.setApiClientUsingDefault(defaultClient);
                    try
                    {
                        CoQuanQuanLy cqql = apiCoQuanQuanLy3.CoquanquanlysMaGet("00001");
                        if (cqql != null)
                        {
                            Console.WriteLine("---------------------");
                            Console.WriteLine("id: " + cqql.Id);
                            Console.WriteLine("ma: " + cqql.Ma);
                            Console.WriteLine("ten: " + cqql.Ten);
                            Console.WriteLine("diaChi: " + cqql.DiaChi);
                            Console.WriteLine("dienThoai: " + cqql.DienThoai);
                            Console.WriteLine("email: " + cqql.Email);
                            Console.WriteLine("fax: " + cqql.Fax);
                            Console.WriteLine("website: " + cqql.Website);
                            Console.WriteLine("cap: " + cqql.Cap);
                            Console.WriteLine("capTren: " + cqql.CapTren);
                            Console.WriteLine("donViHanhChinh: " + cqql.DonViHanhChinh);
                        }
                    }
                    catch (ApiException e)
                    {
                        
                    }
                    break;
                case 9:
                    // Lấy danh sách dân tộc
                    DantocsApi apiDanToc = new DantocsApi();
                    apiDanToc.Configuration.setApiClientUsingDefault(defaultClient);
                    try
                    {
                        List<DanToc> listDanToc = apiDanToc.DantocsGet();
                        foreach (DanToc danToc in listDanToc)
                        {
                            Console.WriteLine("---------------------");
                            Console.WriteLine("id: " + danToc.Id);
                            Console.WriteLine("maDanToc: " + danToc.MaDanToc);
                            Console.WriteLine("tenGoi: " + danToc.TenGoi);
                            Console.WriteLine("tenKhac: " + danToc.TenKhac);
                        }
                    }
                    catch (ApiException e)
                    {
                        
                    }
                    break;
                case 10:
                    // Lấy dân tộc theo ID
                    DantocsApi apiDanToc2 = new DantocsApi();
                    apiDanToc2.Configuration.setApiClientUsingDefault(defaultClient);
                    try
                    {
                        DanToc danToc = apiDanToc2.DantocsIdGet("1");
                        if (danToc != null)
                        {
                            Console.WriteLine("id: " + danToc.Id);
                            Console.WriteLine("maDanToc: " + danToc.MaDanToc);
                            Console.WriteLine("tenGoi: " + danToc.TenGoi);
                            Console.WriteLine("tenKhac: " + danToc.TenKhac);
                        }
                    }
                    catch (ApiException e)
                    {
                        
                    }
                    break;
                case 11:
                    // Lấy danh sách tôn giáo
                    TongiaosApi apiTonGiao = new TongiaosApi();
                    apiTonGiao.Configuration.setApiClientUsingDefault(defaultClient);
                    try
                    {
                        List<TonGiao> listTonGiao = apiTonGiao.TongiaosGet();
                        foreach (TonGiao tonGiao in listTonGiao)
                        {
                            Console.WriteLine("---------------------");
                            Console.WriteLine("id: " + tonGiao.Id);
                            Console.WriteLine("maTonGiao: " + tonGiao.MaTonGiao);
                            Console.WriteLine("tenGoi: " + tonGiao.TenGoi);
                            Console.WriteLine("tenKhac: " + tonGiao.TenKhac);
                        }
                    }
                    catch (ApiException e)
                    {
                        
                    }
                    break;
                case 12:
                    // Lấy tôn giáo theo ID
                    TongiaosApi apiTonGiao2 = new TongiaosApi();
                    apiTonGiao2.Configuration.setApiClientUsingDefault(defaultClient);
                    try
                    {
                        TonGiao tonGiao = apiTonGiao2.TongiaosIdGet(1);
                        if (tonGiao != null)
                        {
                            Console.WriteLine("---------------------");
                            Console.WriteLine("id: " + tonGiao.Id);
                            Console.WriteLine("maTonGiao: " + tonGiao.MaTonGiao);
                            Console.WriteLine("tenGoi: " + tonGiao.TenGoi);
                            Console.WriteLine("tenKhac: " + tonGiao.TenKhac);
                        }
                    }
                    catch (ApiException e)
                    {
                        
                    }
                    break;
                case 13:
                    // Lấy danh sách loại đơn vị đo lường
                    LoaidonvidoluongsApi apiLoaiDonViDoLuong = new LoaidonvidoluongsApi();
                    apiLoaiDonViDoLuong.Configuration.setApiClientUsingDefault(defaultClient);
                    try
                    {
                        List<LoaiDonViDoLuong> listLoaiDonViDoLuong = apiLoaiDonViDoLuong.LoaidonvidoluongsGet();
                        foreach (var loai in listLoaiDonViDoLuong)
                        {
                            Console.WriteLine("---------------------");
                            Console.WriteLine("id: " + loai.Id);
                            Console.WriteLine("ten: " + loai.Ten);
                        }
                    }
                    catch (ApiException e)
                    {
                        
                    }
                    break;
                case 14:
                    // Lấy loại đơn vị đo lường theo ID
                    LoaidonvidoluongsApi apiLoaiDonViDoLuong2 = new LoaidonvidoluongsApi();
                    apiLoaiDonViDoLuong2.Configuration.setApiClientUsingDefault(defaultClient);
                    try
                    {
                        LoaiDonViDoLuong loai = apiLoaiDonViDoLuong2.LoaidonvidoluongsIdGet(1);
                        if (loai != null)
                        {
                            Console.WriteLine("---------------------");
                            Console.WriteLine("id: " + loai.Id);
                            Console.WriteLine("ten: " + loai.Ten);
                        }
                    }
                    catch (ApiException e)
                    {
                        
                    }
                    break;
                case 15:
                    // Lấy danh sách đơn vị đo lường
                    DonvidoluongsApi apiDonViDoLuong = new DonvidoluongsApi();
                    apiDonViDoLuong.Configuration.setApiClientUsingDefault(defaultClient);
                    try
                    {
                        List<DonViDoLuong> listDonViDoLuong = apiDonViDoLuong.DonvidoluongsGet();
                        foreach (var donViDoLuong in listDonViDoLuong)
                        {
                            Console.WriteLine("---------------------");
                            Console.WriteLine("id: " + donViDoLuong.Id);
                            Console.WriteLine("daiLuong: " + donViDoLuong.DaiLuong);
                            Console.WriteLine("kyHieu: " + donViDoLuong.KyHieu);
                            Console.WriteLine("kyHieuSI: " + donViDoLuong.KyHieuSI);
                            Console.WriteLine("tenDonVi: " + donViDoLuong.TenDonVi);
                            Console.WriteLine("tenTA: " + donViDoLuong.TenTA);
                        }
                    }
                    catch (ApiException e)
                    {
                        
                    }
                    break;
                case 16:
                    // Lấy đơn vị đo lường theo ID
                    DonvidoluongsApi apiDonViDoLuong2 = new DonvidoluongsApi();
                    apiDonViDoLuong2.Configuration.setApiClientUsingDefault(defaultClient);
                    try
                    {
                        DonViDoLuong donViDoLuong = apiDonViDoLuong2.DonvidoluongsIdGet(1);
                        if (donViDoLuong != null)
                        {
                            Console.WriteLine("---------------------");
                            Console.WriteLine("id: " + donViDoLuong.Id);
                            Console.WriteLine("daiLuong: " + donViDoLuong.DaiLuong);
                            Console.WriteLine("kyHieu: " + donViDoLuong.KyHieu);
                            Console.WriteLine("kyHieuSI: " + donViDoLuong.KyHieuSI);
                            Console.WriteLine("tenDonVi: " + donViDoLuong.TenDonVi);
                            Console.WriteLine("tenTA: " + donViDoLuong.TenTA);
                        }
                    }
                    catch (ApiException e)
                    {
                        
                    }
                    break;
                default:
                    break;
            }

            Console.ReadKey();
        }
    }
}
