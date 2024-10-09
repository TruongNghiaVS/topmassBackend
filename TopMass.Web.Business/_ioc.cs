﻿using Microsoft.Extensions.DependencyInjection;
using Topmass.Web.Business;
using Topmass.Web.Repository;

namespace TopMass.Web.Business
{
    public static class DependencyRegister
    {
        public static void ConfigRepWeb(this IServiceCollection services)
        {

            services.ConfigRep();
            services.AddSingleton<IArticleBusiness, ArticleBusiness>();
            services.AddSingleton<ICategoryArticleBusiness, CategoryArticleBusiness>();

            services.AddSingleton<IPageWebBusiness, PageWebBusiness>();
            services.AddSingleton<IPageBusiness, PageBusiness>();

        }
    }
}
