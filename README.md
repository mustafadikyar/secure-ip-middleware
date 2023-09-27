# SecureIpMiddleware

ASP.NET Core uygulamalarında gelen istekleri belirli IP adresleriyle sınırlayan basit bir güvenlik middleware'i.

## Kullanım

Middleware'i uygulamanızın Startup.cs dosyasında eklemek için aşağıdaki adımları izleyebilirsiniz:

1. Projenize SecureIpMiddleware sınıfını ekleyin.

2. Middleware'i ConfigureServices metodu içinde aşağıdaki gibi ekleyin:

```csharp
public void Configure(IApplicationBuilder app)
{
    // ...
    app.UseMiddleware<SecureIpMiddleware>();
    // ...
}
```

Varsayılan olarak, 127.0.0.1 (localhost IPv4) ve ::1 (localhost IPv6) adresleri siyah listeye alınmıştır. İzin verilen ve engellenen IP adreslerini düzenlemek için _ipBlackList dizisini güncelleyebilirsiniz.


Middleware, belirli IP adreslerini kara listeye alma yeteneği sunar. Kara listedeki bir IP adresine gelen bir istek, HTTP 403 Forbidden yanıtıyla reddedilir.


Bu middleware, ASP.NET Core uygulamanızın güvenliğini artırmak ve belirli IP adreslerinin erişimini kontrol etmek için kullanışlıdır.
