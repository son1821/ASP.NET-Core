namespace hello_asp{
    class Program
    {
        /* 
         1) tao IHostBuilder
        2) Cau hinh, dang ky cac dich vu(goi ConfigureWebHostDefaults)
        3)IHostBuilder.Build() => Host (IHost)
        4)Host.Run();
         Rquest => pipeline(Middleware) (Su dung webBuilder de xay dung pipeline)
         */
        //static void Main(string[] args)
        //{
        //    Console.WriteLine("Start App");
        //    IHostBuilder builder = Host.CreateDefaultBuilder(args);
        //    //Cau hinh mac dinh cho Host tao ra
        //    builder.ConfigureWebHostDefaults((webBuilder) => {
        //        //Tuy bien them ve Host
        //        // webBuilder
        //        webBuilder.UseStartup<StartUp>();
        //        //webBuilder.UseWebRoot("public");

        //    });
        //    IHost host = builder.Build();
        //    host.Run();

        //}
        static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            //app.MapGet("/", () => "xin chao ASP.NET CORE 2024");
            app.UseStaticFiles();

            //StatusCodePages
            app.UseStatusCodePages();

            //Request
            //EndpointRoutingMiddleware
            app.UseRouting();


            app.UseEndpoints((endPoint) =>
            {
                //su dung doi tuong IEndpointRouteBuilder de xay dung ra cac diem cuoi 
                endPoint.MapGet("/", async (HttpContext context) =>
                {
                    //npm (nodejs)
                    string html = @"
                <!DOCTYPE html>
                <html>
                <head>
                    <meta charset=""UTF-8"">
                    <meta name=""viewport"" content=""width=device-width, initial-scale=1"">
                    <title>Trang web đầu tiên</title>
                    <link rel=""stylesheet"" href=""/css/bootstrap.min.css"" />
                    <script src=""/js/jquery.min.js""></script>
                    <script src=""/js/popper.min.js""></script>
                    <script src=""/js/bootstrap.min.js""></script>


                </head>
                <body>
                    <nav class=""navbar navbar-expand-lg navbar-dark bg-danger"">
                            <a class=""navbar-brand"" href=""#"">Brand-Logo</a>
                            <button class=""navbar-toggler"" type=""button"" data-toggle=""collapse"" data-target=""#my-nav-bar"" aria-controls=""my-nav-bar"" aria-expanded=""false"" aria-label=""Toggle navigation"">
                                    <span class=""navbar-toggler-icon""></span>
                            </button>
                            <div class=""collapse navbar-collapse"" id=""my-nav-bar"">
                            <ul class=""navbar-nav"">
                                <li class=""nav-item active"">
                                    <a class=""nav-link"" href=""#"">Trang chủ</a>
                                </li>
                            
                                <li class=""nav-item"">
                                    <a class=""nav-link"" href=""#"">Học HTML</a>
                                </li>
                            
                                <li class=""nav-item"">
                                    <a class=""nav-link disabled"" href=""#"">Gửi bài</a>
                                </li>
                        </ul>
                        </div>
                    </nav> 
                    <p class=""display-4 text-danger"">Đây là trang đã có Bootstrap</p>
                </body>
                </html>
    ";
                    await context.Response.WriteAsync(html);
                });

                endPoint.MapGet("/about.html", async (HttpContext context) =>
                {
                    await context.Response.WriteAsync("Day la trang gioi thieu");
                });

                endPoint.MapGet("/contact", async (HttpContext context) =>
                {
                    await context.Response.WriteAsync("Day la trang lien he");
                });
            });


            // Terminate Middleware M2 (diem cuoi)
            app.Map("/abc", (app1) =>
            {
                app1.Run(async (HttpContext context) =>
                {
                    await context.Response.WriteAsync("Day la abc");

                });



            });
            app.Run();
        }
    }
    }



