using System;
using Microsoft.EntityFrameworkCore;
using PostService.Entities;

namespace PostService.Data;

public class DbInitializer
{
    public static void InitDb(WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        SeedData(scope.ServiceProvider.GetRequiredService<DataContext>());
    }

    private static void SeedData(DataContext context)
    {
        context.Database.Migrate();

        if (context.Posts.Any())
        {
            Console.WriteLine("DB has been seeded");
            return; 
        }   

        var posts = new List<Post>()
        {
            new Post
            {
                Id = Guid.NewGuid(),
                Title = "Buurthulp: Wie kan mij helpen met boodschappen?",
                Content = "Hallo buurtbewoners! Door een blessure kan ik deze week niet zelf boodschappen doen. Is er iemand die mij zou kunnen helpen? Ik woon aan de Hoofdstraat 25. Graag zou ik woensdagmiddag de boodschappen willen doen. Natuurlijk vergoed ik alle kosten en geef ik een kleine attentie voor de moeite!",
                Author = "Maria van der Berg",
                CreatedAt = DateTime.UtcNow.AddDays(-10),
                UpdatedAt = DateTime.UtcNow.AddDays(-10),
                ImageUrl = "https://unsplash.com/photos/-LJmvGXl6yg/download?force=true"
            },
            new Post
            {
                Id = Guid.NewGuid(),
                Title = "Gratis hulp bij tuinonderhoud voor senioren",
                Content = "Ik ben student en wil graag iets terugdoen voor onze gemeenschap. Ik bied gratis hulp aan bij tuinonderhoud voor senioren in onze buurt. Denk aan onkruid wieden, gras maaien, heggen knippen. Stuur me een berichtje als je hulp nodig hebt!",
                Author = "Tom Jansen",
                CreatedAt = DateTime.UtcNow.AddDays(-8),
                UpdatedAt = DateTime.UtcNow.AddDays(-8),
                ImageUrl = "https://unsplash.com/photos/-LJmvGXl6yg/download?force=true"
            },
            new Post
            {
                Id = Guid.NewGuid(),
                Title = "Buurtschoonmaakdag: Wie doet er mee?",
                Content = "Het wordt tijd om onze buurt weer eens goed schoon te maken! Ik organiseer aanstaande zaterdag een buurtschoonmaakdag. We beginnen om 9:00 bij het wijkcentrum. Neem je eigen handschoenen mee, zakken en grijpers zorgen we voor. Na afloop drinken we samen koffie!",
                Author = "Linda de Vries",
                CreatedAt = DateTime.UtcNow.AddDays(-7),
                UpdatedAt = DateTime.UtcNow.AddDays(-7),
                ImageUrl = "https://unsplash.com/photos/-LJmvGXl6yg/download?force=true"
            },
            new Post
            {
                Id = Guid.NewGuid(),
                Title = "Oppas ruil: Jouw avondje uit, mijn hulp",
                Content = "Ben je ouder en wil je graag eens een avondje uit? Ik bied aan om op je kinderen te passen in ruil voor een wederdienst wanneer ik het nodig heb. Ik heb ervaring met kinderen van alle leeftijden en kan goede referenties geven.",
                Author = "Sophie Bakker",
                CreatedAt = DateTime.UtcNow.AddDays(-6),
                UpdatedAt = DateTime.UtcNow.AddDays(-6),
                ImageUrl = "https://unsplash.com/photos/-LJmvGXl6yg/download?force=true"
            },
            new Post
            {
                Id = Guid.NewGuid(),
                Title = "Gratis computer hulp voor senioren",
                Content = "Worstelt u met uw computer, tablet of smartphone? Ik ben IT-student en bied gratis computerhulp aan senioren in onze wijk. Van het instellen van apps tot het versturen van e-mails, ik help graag! Gewoon contact opnemen.",
                Author = "David Chen",
                CreatedAt = DateTime.UtcNow.AddDays(-5),
                UpdatedAt = DateTime.UtcNow.AddDays(-5),
                ImageUrl = "https://unsplash.com/photos/-LJmvGXl6yg/download?force=true"
            },
            new Post
            {
                Id = Guid.NewGuid(),
                Title = "Buurtmoestuin project: Meedoen?",
                Content = "We willen graag een buurtmoestuin starten in het braakliggende terrein bij de speeltuin. Wie heeft er zin om mee te doen? We kunnen samen groenten kweken en de oogst delen. Het is ook een mooie manier om de buurt groener en gezelliger te maken!",
                Author = "Peter Willems",
                CreatedAt = DateTime.UtcNow.AddDays(-4),
                UpdatedAt = DateTime.UtcNow.AddDays(-4),
                ImageUrl = "https://unsplash.com/photos/-LJmvGXl6yg/download?force=true"
            },
            new Post
            {
                Id = Guid.NewGuid(),
                Title = "Hulp nodig bij verhuizing volgende week",
                Content = "Mijn zoon en ik gaan volgende week verhuizen en kunnen wel wat extra handen gebruiken. Het gaat om een verhuizing binnen de wijk, dus niet ver. Als beloning trakteren we op pizza en drankjes! Zaterdag vanaf 10:00 uur.",
                Author = "Karin Smit",
                CreatedAt = DateTime.UtcNow.AddDays(-3),
                UpdatedAt = DateTime.UtcNow.AddDays(-3),
                ImageUrl = "https://unsplash.com/photos/-LJmvGXl6yg/download?force=true"
            },
            new Post
            {
                Id = Guid.NewGuid(),
                Title = "Buurtbibliotheek in de boekenkast bij de bushalte",
                Content = "Goed nieuws! We hebben een buurtbibliotheek geplaatst bij de bushalte op het pleintje. Iedereen kan gratis boeken lenen en inleveren. Help mee door je uitgelezen boeken toe te voegen. Lezen is leuk en dit maakt onze buurt nog leuker!",
                Author = "Els van Dijk",
                CreatedAt = DateTime.UtcNow.AddDays(-2),
                UpdatedAt = DateTime.UtcNow.AddDays(-2),
                ImageUrl = "https://unsplash.com/photos/-LJmvGXl6yg/download?force=true"
            },
            new Post
            {
                Id = Guid.NewGuid(),
                Title = "Wie wil meehelpen met hondenuitlaatservice?",
                Content = "Voor oudere buurtbewoners die niet meer zo goed ter been zijn, willen we een hondenuitlaatservice opzetten. Wie heeft er tijd en zin om af en toe een hondje uit te laten? Het is ook gezellig voor de hondjes en hun baasjes!",
                Author = "Mark Peters",
                CreatedAt = DateTime.UtcNow.AddDays(-1),
                UpdatedAt = DateTime.UtcNow.AddDays(-1),
                ImageUrl = "https://unsplash.com/photos/-LJmvGXl6yg/download?force=true"
            },
            new Post
            {
                Id = Guid.NewGuid(),
                Title = "Buurtfeest organisatie: Wie helpt mee?",
                Content = "Het is alweer een jaar geleden sinds ons laatste buurtfeest! Tijd voor een nieuw feest om iedereen weer bij elkaar te brengen. Wie wil helpen met organiseren? We hebben mensen nodig voor catering, entertainment, opruimen en meer.",
                Author = "Anna Kooistra",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                ImageUrl = "https://unsplash.com/photos/-LJmvGXl6yg/download?force=true"
            },
            new Post
            {
                Id = Guid.NewGuid(),
                Title = "Gereedschap delen: Mijn boormachine staat voor je klaar",
                Content = "Waarom zou iedereen een boormachine moeten kopen als we kunnen delen? Mijn boormachine staat klaar voor buurtbewoners die hem nodig hebben. Laten we meer van dit soort initiatieven starten! Welke gereedschappen kun jij delen?",
                Author = "Robert de Wit",
                CreatedAt = DateTime.UtcNow.AddHours(-23),
                UpdatedAt = DateTime.UtcNow.AddHours(-23),
                ImageUrl = "https://unsplash.com/photos/-LJmvGXl6yg/download?force=true"
            },
            new Post
            {
                Id = Guid.NewGuid(),
                Title = "Buurtwacht: Samen zorgen voor veiligheid",
                Content = "We merken dat er de laatste tijd meer fietsdiefstallen zijn in onze buurt. Wie heeft er zin om mee te doen aan een buurtwacht? We kunnen wandelingetjes maken en een oogje in het zeil houden. Samen staan we sterker!",
                Author = "Jan Mulder",
                CreatedAt = DateTime.UtcNow.AddHours(-20),
                UpdatedAt = DateTime.UtcNow.AddHours(-20),
                ImageUrl = "https://example.com/images/neighborhood-watch.jpg"
            },
            new Post
            {
                Id = Guid.NewGuid(),
                Title = "Kinderen leren fietsen: Gratis fietsles!",
                Content = "Ik ben een gepensioneerde gymleraar en wil graag kinderen in de buurt helpen om te leren fietsen. Gratis natuurlijk! Iedere zaterdagochtend op het parkeerterrein achter de school. Neem je eigen fiets mee, de rest regel ik.",
                Author = "Henk van der Meer",
                CreatedAt = DateTime.UtcNow.AddHours(-18),
                UpdatedAt = DateTime.UtcNow.AddHours(-18),
                ImageUrl = "https://example.com/images/bike-lessons.jpg"
            },
            new Post
            {
                Id = Guid.NewGuid(),
                Title = "Huisdieren opvang tijdens vakantie",
                Content = "Ga je op vakantie en zoek je opvang voor je huisdier? Wij hebben ervaring met verschillende dieren en zorgen graag voor jouw trouwe viervoeter. In ruil zouden we het fijn vinden als jij op onze kat past wanneer wij weggaan!",
                Author = "Lisa en Mike",
                CreatedAt = DateTime.UtcNow.AddHours(-15),
                UpdatedAt = DateTime.UtcNow.AddHours(-15),
                ImageUrl = "https://example.com/images/pet-sitting.jpg"
            },
            new Post
            {
                Id = Guid.NewGuid(),
                Title = "Repair Café: Samen repareren in plaats van weggooien",
                Content = "Elke tweede zondag van de maand organiseren we een Repair Café in het wijkcentrum. Breng kapotte spullen mee en we kijken samen of we ze kunnen repareren. Goed voor het milieu en gezellig om samen te doen!",
                Author = "Femke Jansen",
                CreatedAt = DateTime.UtcNow.AddHours(-12),
                UpdatedAt = DateTime.UtcNow.AddHours(-12),
                ImageUrl = "https://example.com/images/repair-cafe.jpg"
            },
            new Post
            {
                Id = Guid.NewGuid(),
                Title = "Taalmaatjes gezocht voor nieuwe buren",
                Content = "We hebben nieuwe buren gekregen uit Syrië en ze willen graag Nederlands leren. Wie wil er taalmaatje worden? Je hoeft geen leraar te zijn, gewoon geduld hebben en tijd om te oefenen. Het is een mooie manier om elkaar beter te leren kennen!",
                Author = "Inge Scholten",
                CreatedAt = DateTime.UtcNow.AddHours(-9),
                UpdatedAt = DateTime.UtcNow.AddHours(-9),
                ImageUrl = "https://example.com/images/language-buddy.jpg"
            },
            new Post
            {
                Id = Guid.NewGuid(),
                Title = "Buurt-app groepsaankopen: Samen goedkoper winkelen",
                Content = "Wie heeft er interesse in groepsaankopen? We kunnen samen grote verpakkingen kopen en verdelen. Denk aan wasmiddel, toiletpapier, of seizoensgroenten. Goedkoper en minder verpakking! Reageer als je mee wilt doen.",
                Author = "Carla Verhoeven",
                CreatedAt = DateTime.UtcNow.AddHours(-6),
                UpdatedAt = DateTime.UtcNow.AddHours(-6),
                ImageUrl = "https://example.com/images/group-buying.jpg"
            },
            new Post
            {
                Id = Guid.NewGuid(),
                Title = "Seniorenuitjes: Gezellig samen op pad",
                Content = "Voor alle senioren in onze buurt: wie heeft er zin in maandelijkse uitjes? We kunnen samen naar musea, parken bezoeken of gezellig lunchen. Transport kunnen we samen regelen. Het is fijn om niet altijd alleen te hoeven gaan!",
                Author = "Greet Wouters",
                CreatedAt = DateTime.UtcNow.AddHours(-4),
                UpdatedAt = DateTime.UtcNow.AddHours(-4),
                ImageUrl = "https://example.com/images/senior-outings.jpg"
            },
            new Post
            {
                Id = Guid.NewGuid(),
                Title = "Klusjesman voor kleine reparaties",
                Content = "Ben je handig en wil je andere buurtbewoners helpen met kleine klusjes? Denk aan het ophangen van schilderijen, lekkende kranen of piepende deuren. Ik start een lijst van handige buren die elkaar kunnen helpen!",
                Author = "Ron van Leeuwen",
                CreatedAt = DateTime.UtcNow.AddHours(-2),
                UpdatedAt = DateTime.UtcNow.AddHours(-2),
                ImageUrl = "https://example.com/images/handyman-help.jpg"
            },
            new Post
            {
                Id = Guid.NewGuid(),
                Title = "Gezamenlijke maaltijden voor alleenstaanden",
                Content = "Eet je vaak alleen en vind je dat niet zo gezellig? Iedere donderdagavond organiseren we een gemeenschappelijke maaltijd in het wijkcentrum. Iedereen neemt iets mee en we eten samen. Aanmelden is niet nodig, gewoon komen!",
                Author = "Marijke van der Pol",
                CreatedAt = DateTime.UtcNow.AddHours(-1),
                UpdatedAt = DateTime.UtcNow.AddHours(-1),
                ImageUrl = "https://example.com/images/community-dinner.jpg"
            }            
        };

        context.Posts.AddRange(posts);
        context.SaveChanges();
    }
}
