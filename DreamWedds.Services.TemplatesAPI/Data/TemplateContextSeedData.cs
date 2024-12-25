using DreamWedds.Services.TemplatesAPI.Entities;
using MongoDB.Driver;

namespace DreamWedds.Services.TemplatesAPI.Data
{
    public class TemplateContextSeedData
    {
        public static void SeedData(IMongoCollection<TemplateMaster> productCollection)
        {
            bool existProduct = productCollection.Find(p => true).Any();
            if (!existProduct)
            {
                productCollection.InsertManyAsync(AddTemplates());
            }
        }

        private static IEnumerable<TemplateMaster> AddTemplates()
        {
            var data = new List<TemplateMaster>
{
    new TemplateMaster
    {
        Id = Guid.NewGuid(),
        Name = "Aerial",
        Type = 2,
        Cost = 4900.00m,
        Status = 1,
        Content = null,
        Subject = "Aerial View Wedding Template",
        Tags = "CountDown, TimeLine, Events, Gallery",
        TemplateUrl = "Aerial",
        ThumbnailImageUrl = "/templates/weddings/aerial/thumbnail.png",
        TagLine = "Your Day, Your-Way Moments and Milestones",
        MetaTags = new List<MetaTags>{ new MetaTags { Id = Guid.NewGuid(), Key = "description", KeyValue = "This is my details" } },
        AboutTemplate = "Your Day, Your-Way Moments and MilestonesYour Day, Your-Way Moments and MilestonesYour Day, Your-Way Moments and MilestonesYour Day, Your-Way Moments and MilestonesYour Day, Your-Way Moments and MilestonesYour Day, Your-Way Moments and Milestones"
    },
    new TemplateMaster
    {
        Id = Guid.NewGuid(),
        Name = "Amber",
        Type = 4,
        Cost = 100.00m,
        Status = 2,
        Content = null,
        Subject = "Amber Invitation",
        Tags = "Responsive, Single Page, Static, Unique, Minimalistic",
        TemplateUrl = "/templates/invitation/amber/index.html",
        ThumbnailImageUrl = "/templates/invitation/amber/images/thumbnail.webp",
        TagLine = null,
        MetaTags = new List<MetaTags>{ new MetaTags { Id = Guid.NewGuid(), Key = "description", KeyValue = "This is my details" },
        new MetaTags { Id = Guid.NewGuid(), Key = "image", KeyValue = "Tag image url" }},
        AboutTemplate = "This is simple and elegant invitation template which reflects the information in focused scene. Its simple and traditional invitation template which never gets old."
    },
    new TemplateMaster
    {
        Id = Guid.NewGuid(),
        Name = "Arya",
        Type = 2,
        Cost = 10000.00m,
        Status = 2,
        Content = null,
        Subject = "Save the date",
        Tags = "CountDown, Couples, TimeLine, Events, Gallery",
        TemplateUrl = "/templates/wedding/arya/index.html",
        ThumbnailImageUrl = "/templates/wedding/arya/images/thumbnail.jpg",
        TagLine = "Save the Date",
        AboutTemplate = "Arya Theme helps you build a custom wedding app with all the information that you would need on your wedding website (and creates web versions as well, of course). Another plus — tons of great looking themes!"
    },
    new TemplateMaster
    {
        Id = Guid.NewGuid(),
        Name = "Bashori",
        Type = 2,
        Cost = 10000.00m,
        Status = 1,
        Content = null,
        Subject = "Bashori Wedding Template",
        Tags = " CountDown, Couples, TimeLine, Events, Friends, Gallery",
        TemplateUrl = "https://dreamwedds.com/templates/wedding/bashori/index.html",
        ThumbnailImageUrl = "templates/wedding/bashori/images/banner/1.jpg",
        TagLine = "Marriage is the part our life. We are waiting for you.",
        AboutTemplate = "Bashori is a gorgeous premium option for luxury weddings. While the most expensive option on this list, Bashori has the most modern and glamorous wedding website templates and come with premium features included, like a custom domain and RSVP support."
    },
    new TemplateMaster
    {
        Id = Guid.NewGuid(),
        Name = "Best Day",
        Type = 2,
        Cost = 25000.00m,
        Status = 1,
        Content = null,
        Subject = "Best Day wedding theme",
        Tags = " Couples, TimeLine, Events, Friends, Gallery",
        TemplateUrl = "https://dreamwedds.com/templates/wedding/best-day/index.html",
        ThumbnailImageUrl = "/templates/wedding/best-day/images/banner.jpg",
        TagLine = "Best Day of life is wedding day. Make it special.",
        AboutTemplate = "A brand new wedding website builder just launched! We really like Best-Day feature list — beyond the fact that its free (yay!), Best Day theme comes with a ton of features like an app, RSVPs, photo support, and more."
    },
    new TemplateMaster
    {
        Id = Guid.NewGuid(),
        Name = "Destiny",
        Type = 2,
        Cost = 12000.00m,
        Status = 1,
        Content = null,
        Subject = "SARA & BEN Getting Married on May 10th, 2018",
        Tags = "CountDown, TimeLine, Events, Friends, Gallery",
        TemplateUrl = "Destiny",
        ThumbnailImageUrl = "http://mutationmedia.net/destiny/img/1.jpg",
        TagLine = "SARA & BEN Getting Married on May 10th, 2018",
        AboutTemplate = "A brand new wedding website theme just launched! We really like Destinys galary — beyond the fact that its not expensive, Destiny theme comes with a ton of features like an BrideMaids and GroomsMen, RSVPs, photo support, and more."
    },
    new TemplateMaster
    {
        Id = Guid.NewGuid(),
        Name = "DreamWedds Contact Us Reply",
        Type = 1,
        Cost = 0.00m,
        Status = 1,
        Content = null,
        Subject = "Thank you for writing us",
        Tags = "1",
        TemplateUrl = "Email Reply",
        ThumbnailImageUrl = "Email Reply",
        TagLine = "Email Reply",
        AboutTemplate = "Email Reply"
    },
    new TemplateMaster
    {
        Id = Guid.NewGuid(),
        Name = "Email confirmation",
        Type = 1,
        Cost = null,
        Status = 1,
        Content = null,
        Subject = "Confirm your email address",
        Tags = "Email",
        TemplateUrl = "Email-Confirmation",
        ThumbnailImageUrl = "/assets/images/template/neela.jpg",
        TagLine = null,
        AboutTemplate = "Email Confirmaition"
    },
    new TemplateMaster
    {
        Id = Guid.NewGuid(),
        Name = "Favorite Gold",
        Type = 2,
        Cost = 24900.00m,
        Status = 2,
        Content = null,
        Subject = "Glanz",
        Tags = "Slider, Couple, Clock, Timeline, BrideMaids, GroomMen",
        TemplateUrl = "http://glanz.starkethemes.com/html/",
        ThumbnailImageUrl = "/templates/weddings/favorite gold/thumbnail.jpeg",
        TagLine = null,
        AboutTemplate = "This is super template for wedding website. Glanz can also be used for a variety of business uses."
    },
    new TemplateMaster
    {
        Id = Guid.NewGuid(),
        Name = "Glenz",
        Type = 2,
        Cost = 20000.00m,
        Status = 1,
        Content = null,
        Subject = "Glanz Wedding Template",
        Tags = "CountDown, TimeLine, Events, Friends, Gallery, Musical",
        TemplateUrl = "/templates/Wedding/glenz/index.html",
        ThumbnailImageUrl = "templates/wedding/glenz/images/banner.jpg",
        TagLine = "This is Glenz Theme for Wedding",
        AboutTemplate = "The newest addition to our list, Glenz has improved leaps and bounds over the last few years. We love the modern looking templates that are responsive Glenz also has very unique and original site designs."
    }
};
            return data;
        }
    }
}
