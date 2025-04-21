<div align=center>系统对接接口文档</div>

- e.g: wms传输数据到mes

```cs

// 对数据加签放到header中传递
// 签名规则：data=数据&systemId=系统id&timestamp=时间戳

// systemId: 系统id (MES开发人员提供)
// secretKey: 密钥 (MES开发人员提供)
// timestamp: 时间戳
// data: 数据
// signature: 签名

// 以下是伪代码

public async Task<string> WmsToMes()
{
    var json = new List<object>()
    {
        new { id=1, code="xx001", name="qqq"},
        new { id=2, code="xx002", name="qqqww"},
    };
    var timestamp = GetTimeStamp();
    var data = JsonHelper.ObjToJson(data);
    var content = $"data={data}&systemId={systemId}&timestamp={timestamp}";
    string signature = Encrypt(content, secretKey);
    Dictionary<string, string> header = new Dictionary<string, string>();
    header.Add("Signature", signature);
    string res = await HttpHelper.PostAsync<string>("https://mes.com/api/xxx", data, header);
    return res
}

/// <summary>
/// 获取时间戳
/// </summary>
/// <returns></returns>
public static long GetTimeStamp()
{
    TimeSpan ts = DateTime.Now.ToUniversalTime() - new DateTime(1970, 1, 1);
    return (long)ts.TotalMilliseconds;
}


/// <summary>
/// 加密
/// </summary>
/// <param name="input"></param>
/// <param name="key"></param>
/// <returns></returns>
public static string Encrypt(string input, string key)
{
    byte[] inputBytes = Encoding.UTF8.GetBytes(input);
    using (var des = DES.Create())
    {
        des.Mode = CipherMode.CBC;
        des.Padding = PaddingMode.PKCS7;
        using (var ms = new MemoryStream())
        {
            byte[] arr_key = Encoding.UTF8.GetBytes(key.Substring(0, 8));
            using (var cs = new CryptoStream(ms, des.CreateEncryptor(arr_key, arr_key), CryptoStreamMode.Write))
            {
                cs.Write(inputBytes, 0, inputBytes.Length);
                cs.FlushFinalBlock();
                return Convert.ToBase64String(ms.ToArray());
            }
        }
    }
}

```