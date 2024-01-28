using Microsoft.AspNetCore.Builder;

namespace hello_asp
{
    public class StartUp
    {
        // dang ky cac dich vu cua ung dung (DI)
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddSingleton
        }

        //xay dung pipeline( chuoi middleware)
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //StaticFileMiddleware
            //wwwroot
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
                    await context.Response.WriteAsync("Day la trang chu");
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
            //Terminate Middleware M1 (diem cuoi) it dung
            //app.Run(async (HttpContext context) => {
            //    await context.Response.WriteAsync("Xin chao day la StarUp");
            //});
           

        }
    }
}
