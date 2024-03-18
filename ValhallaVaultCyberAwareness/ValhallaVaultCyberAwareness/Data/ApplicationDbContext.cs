using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ValhallaVaultCyberAwareness.Data.Models;

namespace ValhallaVaultCyberAwareness.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<CategoryModel> Categories { get; set; }
        public DbSet<SegmentModel> Segments { get; set; }
        public DbSet<SubCategoryModel> SubCategories { get; set; }
        public DbSet<QuestionModel> Questions { get; set; }
        public DbSet<PromptModel> Prompts { get; set; }
        public DbSet<ApplicationUserQuestionModel> ApplicationUserQuestions { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUserQuestionModel>().HasKey(e => new { e.ApplicationUserId, e.QuestionModelId });



            builder.Entity<CategoryModel>().HasData(
            new CategoryModel
            {
                Id = 1,
                CategoryName = "Att skydda sig mot bedrägerier",


            },
            new CategoryModel
            {
                Id = 2,
                CategoryName = "Cybersäkerhet för företag",

            },
            new CategoryModel
            {
                Id = 3,
                CategoryName = "Cyberspionage",

            });

            ////Seedad Segments
            builder.Entity<SegmentModel>().HasData(

            // Segments for category 1
            new SegmentModel
            {
                Id = 1,
                SegmentName = "Del 1",

                CategoryId = 1
            },
            new SegmentModel
            {
                Id = 2,
                SegmentName = "Del 2",

                CategoryId = 1
            },
            new SegmentModel
            {
                Id = 3,
                SegmentName = "Del 3",

                CategoryId = 1
            },

            // Segments for category 2
            new SegmentModel
            {
                Id = 4,
                SegmentName = "Del 1",

                CategoryId = 2
            },
            new SegmentModel
            {
                Id = 5,
                SegmentName = "Del 2",

                CategoryId = 2
            },
            new SegmentModel
            {
                Id = 6,
                SegmentName = "Del 3",

                CategoryId = 2
            },
            new SegmentModel
            {
                Id = 7,
                SegmentName = "Del 4",

                CategoryId = 2
            },

            // Segments for category 3
            new SegmentModel
            {
                Id = 8,
                SegmentName = "Del 1",

                CategoryId = 3
            },
            new SegmentModel
            {
                Id = 9,
                SegmentName = "Del 2",

                CategoryId = 3
            },
            new SegmentModel
            {
                Id = 10,
                SegmentName = "Del 3",

                CategoryId = 3
            });

            //Seeding Subcategories
            builder.Entity<SubCategoryModel>().HasData(

            // Category 1 - "Att skydda sig mot bedrägerier"
            // Subcategories for Segment "Del 1"
            new SubCategoryModel { Id = 1, SubCategoryName = "Kreditkortsbedrägeri", SegmentId = 1 },
            new SubCategoryModel { Id = 2, SubCategoryName = "Säkerhetsåtgärder mot bedrägerier", SegmentId = 1 },
            new SubCategoryModel { Id = 3, SubCategoryName = "Kommunikationsmetoder", SegmentId = 1 },
            new SubCategoryModel { Id = 4, SubCategoryName = "Telefonbedrägeriers förebyggande", SegmentId = 1 },
            new SubCategoryModel { Id = 5, SubCategoryName = "Romansbedrägeri", SegmentId = 1 },
            new SubCategoryModel { Id = 6, SubCategoryName = "Investeringsbedrägeri", SegmentId = 1 },
            new SubCategoryModel { Id = 7, SubCategoryName = "Telefonbedrägeri", SegmentId = 1 },

            // Subcategories for Segment "Del 2"
            new SubCategoryModel { Id = 8, SubCategoryName = "Bedrägerier i hemmet", SegmentId = 2 },
            new SubCategoryModel { Id = 9, SubCategoryName = "Identitetsstöld", SegmentId = 2 },
            new SubCategoryModel { Id = 10, SubCategoryName = "Nätfiske och bluffmejl", SegmentId = 2 },
            new SubCategoryModel { Id = 11, SubCategoryName = "Investeringsbedrägeri på nätet", SegmentId = 2 },

            // Subcategories for Segment "Del 3"
            new SubCategoryModel { Id = 12, SubCategoryName = "Abonnemangsfällor och falska fakturor", SegmentId = 3 },
            new SubCategoryModel { Id = 13, SubCategoryName = "Ransomware", SegmentId = 3 },
            new SubCategoryModel { Id = 14, SubCategoryName = "Statistik och förhållningssätt", SegmentId = 3 },


            // Category 2 - "Cybersäkerhet för företag"
            // Subcategories for Segment "Del 1"
            new SubCategoryModel { Id = 15, SubCategoryName = "Digital säkerhet på företag", SegmentId = 4 },
            new SubCategoryModel { Id = 16, SubCategoryName = "Lösenordshantering", SegmentId = 4 },
            new SubCategoryModel { Id = 17, SubCategoryName = "Säker fjärråtkomst", SegmentId = 4 },
            new SubCategoryModel { Id = 18, SubCategoryName = "E-postsäkerhet", SegmentId = 4 },
            new SubCategoryModel { Id = 19, SubCategoryName = "Risker och beredskap", SegmentId = 4 },
            new SubCategoryModel { Id = 20, SubCategoryName = "Aktörer inom cyberbrott", SegmentId = 4 },
            new SubCategoryModel { Id = 21, SubCategoryName = "Ökad digital närvaro och distansarbete", SegmentId = 4 },
            new SubCategoryModel { Id = 22, SubCategoryName = "Cyberangrepp mot känsliga sektorer", SegmentId = 4 },
            new SubCategoryModel { Id = 23, SubCategoryName = "Cyberrånet mot Mersk", SegmentId = 4 },

            // Subcategories for Segment "Del 2"
            new SubCategoryModel { Id = 24, SubCategoryName = "Social engineering", SegmentId = 5 },
            new SubCategoryModel { Id = 25, SubCategoryName = "Nätfiske och skräppost", SegmentId = 5 },
            new SubCategoryModel { Id = 26, SubCategoryName = "Vishing", SegmentId = 5 },
            new SubCategoryModel { Id = 27, SubCategoryName = "Varning för vishing", SegmentId = 5 },
            new SubCategoryModel { Id = 28, SubCategoryName = "Identifiera VD-mejl", SegmentId = 5 },
            new SubCategoryModel { Id = 29, SubCategoryName = "Öneangrepp och presentkortsbluffar", SegmentId = 5 },

            // Subcategories for Segment "Del 3"
            new SubCategoryModel { Id = 30, SubCategoryName = "Virus, maskar och trojaner", SegmentId = 6 },
            new SubCategoryModel { Id = 31, SubCategoryName = "Så kan det gå till", SegmentId = 6 },
            new SubCategoryModel { Id = 32, SubCategoryName = "Nätverksintrång", SegmentId = 6 },
            new SubCategoryModel { Id = 33, SubCategoryName = "Dataintrång", SegmentId = 6 },
            new SubCategoryModel { Id = 34, SubCategoryName = "Hackad!", SegmentId = 6 },
            new SubCategoryModel { Id = 35, SubCategoryName = "Vägarna in", SegmentId = 6 },

            // Subcategories for Segment "Del 4"
            new SubCategoryModel { Id = 36, SubCategoryName = "Utpressningsvirus", SegmentId = 7 },
            new SubCategoryModel { Id = 37, SubCategoryName = "Attacker mot servrar", SegmentId = 7 },
            new SubCategoryModel { Id = 38, SubCategoryName = "Cyberangrepp i Norden", SegmentId = 7 },
            new SubCategoryModel { Id = 39, SubCategoryName = "It-brottslingarnas verktyg", SegmentId = 7 },
            new SubCategoryModel { Id = 40, SubCategoryName = "Mirai, Wannacry och fallet Düsseldorf", SegmentId = 7 },
            new SubCategoryModel { Id = 41, SubCategoryName = "De sårbara molnen", SegmentId = 7 },


            // Category 3 - "Cyberspionage"
            // Subcategories for "Cyberspionage", Segment "Del 1"
            new SubCategoryModel { Id = 42, SubCategoryName = "Allmänt om cyberspionage", SegmentId = 8 },
            new SubCategoryModel { Id = 43, SubCategoryName = "Kryptering", SegmentId = 8 },
            new SubCategoryModel { Id = 44, SubCategoryName = "Insiderhot", SegmentId = 8 },
            new SubCategoryModel { Id = 45, SubCategoryName = "Mjukvarusårbarheter i cyberspionageattacker.", SegmentId = 8 },
            new SubCategoryModel { Id = 46, SubCategoryName = "Metoder för cyberspionage", SegmentId = 8 },
            new SubCategoryModel { Id = 47, SubCategoryName = "Säkerhetsskyddslagen", SegmentId = 8 },
            new SubCategoryModel { Id = 48, SubCategoryName = "Cyberspionagets aktörer", SegmentId = 8 },

            // Subcategories for "Cyberspionage", Segment "Del 2"
            new SubCategoryModel { Id = 49, SubCategoryName = "Värvningsförsök", SegmentId = 9 },
            new SubCategoryModel { Id = 50, SubCategoryName = "Affärsspionage", SegmentId = 9 },
            new SubCategoryModel { Id = 51, SubCategoryName = "Påverkanskampanjer", SegmentId = 9 },

            // Subcategories for "Cyberspionage", Segment "Del 3"
            new SubCategoryModel { Id = 52, SubCategoryName = "Svensk underrättelsetjänst och cyberförsvar", SegmentId = 10 },
            new SubCategoryModel { Id = 53, SubCategoryName = "Signalspaning, informationssäkerhet och 5G", SegmentId = 10 },
            new SubCategoryModel { Id = 54, SubCategoryName = "Samverkan mot cyberspionage", SegmentId = 10 }
            );


            builder.Entity<QuestionModel>().HasData(

            // Category - "Att skydda sig mot bedrägerier"
            // Questions for segment - "Del 1"
            new QuestionModel { Id = 1, Question = "Du får ett oväntat telefonsamtal från någon som påstår sig vara från din bank. Personen ber dig bekräfta ditt kontonummer och lösenord för att \"säkerställa din kontos säkerhet\" efter en påstådd säkerhetsincident. Hur bör du tolka denna situation?", SubCategoryId = 1 },
            new QuestionModel { Id = 2, Question = "Vad bör du göra omedelbart efter att ha mottagit ett misstänkt telefonsamtal där någon frågar efter personlig finansiell information?", SubCategoryId = 2 },
            new QuestionModel { Id = 3, Question = "Vilket av följande påståenden är sant angående hur finansiella institutioner kommunicerar med sina kunder?", SubCategoryId = 3 },
            new QuestionModel { Id = 4, Question = "Hur kan du bäst skydda dig mot telefonbedrägerier?", SubCategoryId = 4 },
            new QuestionModel { Id = 5, Question = "Efter flera månader av daglig kommunikation med någon du träffade på en datingsida, börjar personen berätta om en plötslig finansiell kris och ber om din hjälp genom att överföra pengar. Vad indikerar detta mest sannolikt?", SubCategoryId = 5 },
            new QuestionModel { Id = 6, Question = "Du får ett e-postmeddelande/samtal om ett exklusivt erbjudande att investera i ett startup-företag som påstås ha en revolutionerande ny teknologi, med garantier om exceptionellt hög avkastning på mycket kort tid. Hur bör du förhålla dig till erbjudandet?", SubCategoryId = 6 },
            new QuestionModel { Id = 7, Question = "Efter en online-shoppingrunda märker du oidentifierade transaktioner på ditt kreditkortsutdrag från företag du aldrig handlat från. Vad indikerar detta mest sannolikt?", SubCategoryId = 7 },

            // Questions for segment - "Del 2"
            new QuestionModel { Id = 8, Question = "Vilka är tecknen på att du kan vara utsatt för ett bedrägeri relaterat till hemförsäljning eller hantverkstjänster?", SubCategoryId = 8 },
            new QuestionModel { Id = 9, Question = "Vilka steg bör du ta för att skydda dig mot identitetsstöld?", SubCategoryId = 9 },
            new QuestionModel { Id = 10, Question = "Hur bör du agera om du mottar ett e-postmeddelande som uppmanar dig att uppdatera dina bankuppgifter via en länk?", SubCategoryId = 10 },
            new QuestionModel { Id = 11, Question = "Vad är ett tydligt tecken på ett online-investeringsbedrägeri?", SubCategoryId = 11 },

            // Questions for segment - "Del 3"
            new QuestionModel { Id = 12, Question = "Hur kan du undvika att falla för abonnemangsfällor?", SubCategoryId = 12 },
            new QuestionModel { Id = 13, Question = "Vad är det bästa sättet att skydda dig mot ransomware-attacker?", SubCategoryId = 13 },
            new QuestionModel { Id = 14, Question = "Vad visar statistiken om allmänhetens förhållningssätt till cybersäkerhet?", SubCategoryId = 14 },


            // Category - "Cybersäkerhet för företag"
            // Questions for segment - "Del 1"
            new QuestionModel { Id = 15, Question = "Inom företaget märker man att konfidentiella dokument regelbundet läcker ut till konkurrenter. Efter en intern granskning upptäcks det att en anställd omedvetet har installerat skadlig programvara genom att klicka på en länk i ett phishing-e-postmeddelande. Vilken åtgärd bör prioriteras för att förhindra framtida incidenter?", SubCategoryId = 15 },
            new QuestionModel { Id = 16, Question = "Vilken åtgärd är mest effektiv för att säkerställa att anställda regelbundet uppdaterar sina lösenord till starkare och mer komplexa versioner?", SubCategoryId = 16 },
            new QuestionModel { Id = 17, Question = "Hur kan företaget effektivt minska risken för att anställda oavsiktligt exponerar företagsdata via otrygga Wi-Fi-nätverk?", SubCategoryId = 17 },
            new QuestionModel { Id = 18, Question = "Vilken åtgärd bör ett företag ta för att skydda sig mot intrång via e-postbaserade hot som phishing?", SubCategoryId = 18 },
            new QuestionModel { Id = 19, Question = "Inom företaget upptäckts det en sårbarhet i vår programvara som kunde möjliggöra obehörig åtkomst till användardata. Företaget har inte omedelbart en lösning. Vilken är den mest lämpliga första åtgärden?", SubCategoryId = 19 },
            new QuestionModel { Id = 20, Question = "Vårt företag blir måltavla för en DDoS-attack som överväldigar våra servers och gör våra tjänster otillgängliga för kunder. Vilken typ av aktör är mest sannolikt ansvarig för denna typ av attack?", SubCategoryId = 20 },
            new QuestionModel { Id = 21, Question = "Med övergången till distansarbete upptäcker vårt företag en ökning av säkerhetsincidenter, inklusive obehörig åtkomst till företagsdata. Vilken åtgärd bör företaget vidta för att adressera denna nya riskmiljö?", SubCategoryId = 21 },
            new QuestionModel { Id = 22, Question = "Hälsovårdsmyndigheten utsätts för ett cyberangrepp som krypterar patientdata och kräver lösen för att återställa åtkomsten. Vilken typ av angrepp har de sannolikt blivit utsatta för?", SubCategoryId = 22 },
            new QuestionModel { Id = 23, Question = "Det globala fraktbolaget Maersk blev offer för ett omfattande cyberangrepp som avsevärt störde deras verksamhet världen över. Vilken typ av malware var primärt ansvarig för denna incident?", SubCategoryId = 23 },

            // Questions for segment - "Del 2"
            new QuestionModel { Id = 24, Question = "Vad är den vanligaste metoden för social engineering?", SubCategoryId = 24 },
            new QuestionModel { Id = 25, Question = "Vad är det mest effektiva sättet att hantera nätfiske?", SubCategoryId = 25 },
            new QuestionModel { Id = 26, Question = "Hur kan man bäst skydda sig mot vishing?", SubCategoryId = 26 },
            new QuestionModel { Id = 27, Question = "Vilket tecken kan tyda på att ett telefonsamtal är ett vishing-försök?", SubCategoryId = 27 },
            new QuestionModel { Id = 28, Question = "Vad bör man göra om man mottar ett e-postmeddelande där VD:n verkar be om konfidentiell information?", SubCategoryId = 28 },
            new QuestionModel { Id = 29, Question = "Hur kan man identifiera ett öneangrepp eller presentkortsbluff?", SubCategoryId = 29 },

            // Questions for segment - "Del 3"
            new QuestionModel { Id = 30, Question = "Vad är skillnaden mellan virus, maskar och trojaner?", SubCategoryId = 30 },
            new QuestionModel { Id = 31, Question = "Hur sker vanligtvis ett dataintrång?", SubCategoryId = 31 },
            new QuestionModel { Id = 32, Question = "Vilka är tecknen på att ditt nätverk kan ha blivit komprometterat?", SubCategoryId = 32 },
            new QuestionModel { Id = 33, Question = "Vilka steg bör tas efter ett upptäckt dataintrång?", SubCategoryId = 33 },
            new QuestionModel { Id = 34, Question = "Vad bör man göra om man upptäcker att ens personliga data har blivit hackad?", SubCategoryId = 34 },
            new QuestionModel { Id = 35, Question = "Vilka är de vanligaste metoderna angripare använder för att infiltrera nätverk?", SubCategoryId = 35 },

            // Questions for segment - "Del 4"
            new QuestionModel { Id = 36, Question = "Vilka åtgärder bör vidtas för att skydda sig mot utpressningsvirus?", SubCategoryId = 36 },
            new QuestionModel { Id = 37, Question = "Hur kan företag förebygga attacker mot sina servrar?", SubCategoryId = 37 },
            new QuestionModel { Id = 38, Question = "Vilken typ av cyberangrepp har varit särskilt utbredda i de nordiska länderna?", SubCategoryId = 38 },
            new QuestionModel { Id = 39, Question = "Vilka verktyg använder IT-brottslingar ofta för att genomföra sina attacker?", SubCategoryId = 39 },
            new QuestionModel { Id = 40, Question = "Vad har dessa cyberangrepp gemensamt?", SubCategoryId = 40 },
            new QuestionModel { Id = 41, Question = "Hur kan organisationer minska risken för säkerhetshot i molnet?", SubCategoryId = 41 },


            // Category - "Cyberspionage"
            // Questions for segment - "Del 1"
            new QuestionModel { Id = 42, Question = "Regeringen upptäcker att känslig politisk kommunikation har läckt och misstänker elektronisk övervakning. Vilket fenomen beskriver bäst denna situation?", SubCategoryId = 42 },
            new QuestionModel { Id = 43, Question = "Vilken försvarsstrategi är mest effektiv mot cyberspionage som riktar sig mot känslig kommunikation?", SubCategoryId = 43 },
            new QuestionModel { Id = 44, Question = "Hur kan organisationer bäst upptäcka och motverka insiderhot som bidrar till cyberspionage?", SubCategoryId = 44 },
            new QuestionModel { Id = 45, Question = "Vilken åtgärd är viktigast för att skydda sig mot cyberspionage genom utnyttjande av mjukvarusårbarheter?", SubCategoryId = 45 },
            new QuestionModel { Id = 46, Question = "Regeringen blir varse om en sofistikerad skadeprogramskampanj som utnyttjar Zero-day sårbarheter för att infiltrera deras nätverk och stjäla oerhört viktig data. Vilken metod för cyberspionage används sannolikt här?", SubCategoryId = 46 },
            new QuestionModel { Id = 47, Question = "Regeringen i Sverige ökar sitt interna säkerhetsprotokoll för att skydda sig mot utländska underrättelsetjänsters infiltration. Vilken lagstiftning ger ramverket för detta skydd?", SubCategoryId = 47 },
            new QuestionModel { Id = 48, Question = "Lunds universitet upptäcker att forskningsdata om ny teknologi har stulits. Undersökningar tyder på en välorganiserad grupp med kopplingar till en utländsk stat. Vilken typ av aktör ligger sannolikt bakom detta?", SubCategoryId = 48 },

            // Questions for segment - "Del 2"
            new QuestionModel { Id = 49, Question = "Hur kan organisationer identifiera och skydda sig mot värvningsförsök av utländska underrättelsetjänster?", SubCategoryId = 49 },
            new QuestionModel { Id = 50, Question = "Vilka tecken kan tyda på att ett företag är målet för affärsspionage?", SubCategoryId = 50 },
            new QuestionModel { Id = 51, Question = "Hur kan samhällen och organisationer försvara sig mot informationspåverkanskampanjer?", SubCategoryId = 51 },

            // Questions for segment - "Del 3"
            new QuestionModel { Id = 52, Question = "Hur arbetar den svenska underrättelsetjänsten med att stärka landets cyberförsvar? ", SubCategoryId = 52 },
            new QuestionModel { Id = 53, Question = "Vilken roll spelar signalspaning och informationssäkerhet i utvecklingen och implementeringen av 5G-teknologi?", SubCategoryId = 53 },
            new QuestionModel { Id = 54, Question = "Hur kan länder effektivt samverka för att bekämpa cyberspionage?", SubCategoryId = 54 }
            );


            // Prompts for each question
            builder.Entity<PromptModel>().HasData(

            // Question 1
            new PromptModel
            {
                Id = 1,
                Prompt = "Ett legitimt försök från banken att skydda ditt konto",
                IsCorrect = false,
                QuestionId = 1,
            },
            new PromptModel
            {
                Id = 2,
                Prompt = "En informationsinsamling för en marknadsundersökning",
                IsCorrect = false,

                QuestionId = 1,
            },
            new PromptModel
            {
                Id = 3,
                Prompt = "Ett potentiellt telefonbedrägeri",
                IsCorrect = true,
                QuestionId = 1,
            },

            // Question 2
            new PromptModel
            {
                Id = 4,
                Prompt = "Ge dem informationen de ber om, för säkerhets skull",
                IsCorrect = false,
                QuestionId = 2
            },
            new PromptModel
            {
                Id = 5,
                Prompt = "Avsluta samtalet och kontakta din bank direkt via ett officiellt nummer du vet är korrekt",
                IsCorrect = true,
                QuestionId = 2
            },
            new PromptModel
            {
                Id = 6,
                Prompt = "Vänta på att de ska ringa tillbaka för att bekräfta deras legitimitet",
                IsCorrect = false,

                QuestionId = 2
            },

            // Question 3
            new PromptModel
            {
                Id = 7,
                Prompt = "Banker skickar ofta e-postmeddelanden som ber kunder att direkt ange lösenord och kontonummer för verifiering.",
                IsCorrect = false,
                QuestionId = 3
            },
            new PromptModel
            {
                Id = 8,
                Prompt = "Banker ringer regelbundet sina kunder för att be dem upprepa sina kontouppgifter för säkerhetsuppdateringar.",
                IsCorrect = false,
                QuestionId = 3
            },
            new PromptModel
            {
                Id = 9,
                Prompt = "Banker och finansiella institutioner kommer aldrig att be dig om ditt lösenord eller kontonummer via telefon eller e-post.",
                IsCorrect = true,
                QuestionId = 3
            },

            // Question 4
            new PromptModel
            {
                Id = 10,
                Prompt = "Installera en app som blockerar misstänkta samtal.",
                IsCorrect = false,
                QuestionId = 4
            },
            new PromptModel
            {
                Id = 11,
                Prompt = "Aldrig svara på samtal från okända nummer.",
                IsCorrect = false,
                QuestionId = 4
            },
            new PromptModel
            {
                Id = 12,
                Prompt = "Upprätta starka säkerhetsfrågor med din bank som krävs för att identifiera dig över telefon.",
                IsCorrect = true,
                QuestionId = 4
            },

            // Question 5
            new PromptModel
            {
                Id = 13,
                Prompt = "En legitim begäran om hjälp från en person i nöd.",
                IsCorrect = false,
                QuestionId = 5
            },
            new PromptModel
            {
                Id = 14,
                Prompt = "Ett romansbedrägeri.",
                IsCorrect = true,
                QuestionId = 5
            },
            new PromptModel
            {
                Id = 15,
                Prompt = "En tillfällig ekonomisk svårighet.",
                IsCorrect = false,
                QuestionId = 5
            },

            // Question 6
            new PromptModel
            {
                Id = 16,
                Prompt = "Genomföra omedelbar investering för att inte missa möjligheten.",
                IsCorrect = false,
                QuestionId = 6
            },
            new PromptModel
            {
                Id = 17,
                Prompt = "Investeringsbedrägeri.",
                IsCorrect = true,
                QuestionId = 6
            },
            new PromptModel
            {
                Id = 18,
                Prompt = "Begära mer information för att utföra en noggrann ?due diligence?.",
                IsCorrect = false,
                QuestionId = 6
            },

            // Question 7
            new PromptModel
            {
                Id = 19,
                Prompt = "Ett misstag av kreditkortsföretaget",
                IsCorrect = false,
                QuestionId = 7
            },
            new PromptModel
            {
                Id = 20,
                Prompt = "Kreditkortsbedrägeri",
                IsCorrect = true,
                QuestionId = 7
            },
            new PromptModel
            {
                Id = 21,
                Prompt = "Obehöriga köp av en familjemedlem",
                IsCorrect = false,
                QuestionId = 7
            },

            // Question 8
            new PromptModel
            {
                Id = 22,
                Prompt = "Säljaren kräver omedelbar betalning eller en stor förskottsbetalning.",
                IsCorrect = false,

                QuestionId = 8
            },
            new PromptModel
            {
                Id = 23,
                Prompt = "Säljaren erbjuder en \"engångserbjudande\" som bara gäller under besöket.",
                IsCorrect = false,

                QuestionId = 8
            },
            new PromptModel
            {
                Id = 24,
                Prompt = "Alla svaren.",
                IsCorrect = true,

                QuestionId = 8
            },

            // Question 9
            new PromptModel
            {
                Id = 25,
                Prompt = "Dela regelbundet personlig information på sociala medier",
                IsCorrect = false,

                QuestionId = 9
            },
            new PromptModel
            {
                Id = 26,
                Prompt = "Övervaka dina kontoutdrag och använd starka, unika lösenord",
                IsCorrect = true,

                QuestionId = 9
            },
            new PromptModel
            {
                Id = 27,
                Prompt = "Använda offentligt Wi-Fi för alla dina finansiella transaktioner",
                IsCorrect = false,

                QuestionId = 9
            },

            // Question 10
            new PromptModel
            {
                Id = 28,
                Prompt = "Klicka på länken och följ instruktionerna",
                IsCorrect = false,

                QuestionId = 10
            },
            new PromptModel
            {
                Id = 29,
                Prompt = "Ignorera e-postmeddelandet och radera det",
                IsCorrect = false,

                QuestionId = 10
            },
            new PromptModel
            {
                Id = 30,
                Prompt = "Kontakta banken direkt via officiella kommunikationskanaler för att verifiera förfrågan",
                IsCorrect = true,

                QuestionId = 10
            },

            // Question 11
            new PromptModel
            {
                Id = 31,
                Prompt = "Garanterad hög avkastning med liten eller ingen risk",
                IsCorrect = true,

                QuestionId = 11
            },
            new PromptModel
            {
                Id = 32,
                Prompt = "Krav på omedelbar investering för att säkra platsen",
                IsCorrect = false,

                QuestionId = 11
            },
            new PromptModel
            {
                Id = 33,
                Prompt = "Erbjudanden som endast baseras på verkliga marknadsförhållanden",
                IsCorrect = false,

                QuestionId = 11
            },

            // Question 12
            new PromptModel
            {
                Id = 34,
                Prompt = "Registrera dig för alla erbjudanden du får via e-post",
                IsCorrect = false,

                QuestionId = 12
            },
            new PromptModel
            {
                Id = 35,
                Prompt = "Läs noggrant igenom avtal och villkor innan du tecknar något abonnemang",
                IsCorrect = true,

                QuestionId = 12
            },
            new PromptModel
            {
                Id = 36,
                Prompt = "Ge ut ditt kreditkortnummer till alla webbplatser som erbjuder gratis prövoperioder",
                IsCorrect = false,

                QuestionId = 12
            },

            // Question 13
            new PromptModel
            {
                Id = 37,
                Prompt = "Öppna bilagor i e-postmeddelanden från okända avsändare",
                IsCorrect = false,

                QuestionId = 13
            },
            new PromptModel
            {
                Id = 38,
                Prompt = "Säkerhetskopiera dina data regelbundet och hålla ditt antivirusprogram uppdaterat",
                IsCorrect = true,

                QuestionId = 13
            },
            new PromptModel
            {
                Id = 39,
                Prompt = "Betala lösen direkt för att få tillbaka dina filer",
                IsCorrect = false,

                QuestionId = 13
            },

            // Question 14
            new PromptModel
            {
                Id = 40,
                Prompt = "Majoriteten av personer är inte medvetna om grundläggande cybersäkerhetsprinciper",
                IsCorrect = true,

                QuestionId = 14
            },
            new PromptModel
            {
                Id = 41,
                Prompt = "De flesta använder komplexa lösenord och ändrar dem regelbundet",
                IsCorrect = false,

                QuestionId = 14
            },
            new PromptModel
            {
                Id = 42,
                Prompt = "En stor del av befolkningen känner sig helt säkra när de surfar på internet",
                IsCorrect = false,

                QuestionId = 14
            },

            // Question 15
            new PromptModel
            {
                Id = 43,
                Prompt = "Utbildning i digital säkerhet för alla anställda",
                IsCorrect = true,

                QuestionId = 15
            },
            new PromptModel
            {
                Id = 44,
                Prompt = "Installera en starkare brandvägg",
                IsCorrect = false,

                QuestionId = 15
            },
            new PromptModel
            {
                Id = 45,
                Prompt = "Byta ut all IT-utrustning",
                IsCorrect = false,

                QuestionId = 15
            },

            // Question 16
            new PromptModel
            {
                Id = 46,
                Prompt = "Manuellt kontrollera varje anställds lösenord en gång per år",
                IsCorrect = false,

                QuestionId = 16
            },
            new PromptModel
            {
                Id = 47,
                Prompt = "Implementera en policy för lösenordskomplexitet som kräver automatiska lösenordsändringar var 90:e dag",
                IsCorrect = true,

                QuestionId = 16
            },
            new PromptModel
            {
                Id = 48,
                Prompt = "Uppmana anställda att välja lättihågda lösenord för att undvika att skriva ner dem",
                IsCorrect = false,

                QuestionId = 16
            },

            // Question 17
            new PromptModel
            {
                Id = 49,
                Prompt = "Förbjuda användning av offentliga Wi-Fi-nätverk helt och hållet",
                IsCorrect = false,

                QuestionId = 17
            },
            new PromptModel
            {
                Id = 50,
                Prompt = "Utrusta alla anställdas enheter med VPN (Virtual Private Network)-tjänster",
                IsCorrect = true,

                QuestionId = 17
            },
            new PromptModel
            {
                Id = 51,
                Prompt = "Endast tillåta anställda att arbeta offline när de inte är på kontoret",
                IsCorrect = false,

                QuestionId = 17
            },

            // Question 18
            new PromptModel
            {
                Id = 52,
                Prompt = "Blockera all inkommande e-post från externa källor",
                IsCorrect = false,

                QuestionId = 18
            },
            new PromptModel
            {
                Id = 53,
                Prompt = "Installera och uppdatera regelbundet e-postsäkerhetslösningar som filtrerar bort skadlig programvara och misstänkta länkar",
                IsCorrect = true,

                QuestionId = 18
            },
            new PromptModel
            {
                Id = 54,
                Prompt = "Låta anställda använda personliga e-postkonton för arbete för att minska risken för företagets e-postservers säkerhet",
                IsCorrect = false,

                QuestionId = 18
            },

            // Question 19
            new PromptModel
            {
                Id = 55,
                Prompt = "Informera alla användare om sårbarheten och rekommendera temporära skyddsåtgärder",
                IsCorrect = true,

                QuestionId = 19
            },
            new PromptModel
            {
                Id = 56,
                Prompt = "Ignorera problemet tills en patch kan utvecklas",
                IsCorrect = false,

                QuestionId = 19
            },
            new PromptModel
            {
                Id = 57,
                Prompt = "Stänga ner tjänsten tillfälligt",
                IsCorrect = false,

                QuestionId = 19
            },

            // Question 20
            new PromptModel
            {
                Id = 58,
                Prompt = "En enskild hackare med ett personligt vendetta",
                IsCorrect = false,

                QuestionId = 20
            },
            new PromptModel
            {
                Id = 59,
                Prompt = "En konkurrerande företagsentitet",
                IsCorrect = false,

                QuestionId = 20
            },
            new PromptModel
            {
                Id = 60,
                Prompt = "Organiserade cyberbrottsliga grupper",
                IsCorrect = true,

                QuestionId = 20
            },

            // Question 21
            new PromptModel
            {
                Id = 61,
                Prompt = "Återgå till kontorsarbete",
                IsCorrect = false,

                QuestionId = 21
            },
            new PromptModel
            {
                Id = 62,
                Prompt = "Införa striktare lösenordspolicyer och tvåfaktorsautentisering för fjärråtkomst",
                IsCorrect = true,

                QuestionId = 21
            },
            new PromptModel
            {
                Id = 63,
                Prompt = "Förbjuda användning av personliga enheter för arbete",
                IsCorrect = false,

                QuestionId = 21
            },

            // Question 22
            new PromptModel
            {
                Id = 64,
                Prompt = "Phishing",
                IsCorrect = false,

                QuestionId = 22
            },
            new PromptModel
            {
                Id = 65,
                Prompt = "Ransomware",
                IsCorrect = true,

                QuestionId = 22
            },
            new PromptModel
            {
                Id = 66,
                Prompt = "Spyware",
                IsCorrect = false,

                QuestionId = 22
            },

            // Question 23
            new PromptModel
            {
                Id = 67,
                Prompt = "Spyware",
                IsCorrect = false,

                QuestionId = 23
            },
            new PromptModel
            {
                Id = 68,
                Prompt = "Ransomware",
                IsCorrect = true,

                QuestionId = 23
            },
            new PromptModel
            {
                Id = 69,
                Prompt = "Adware",
                IsCorrect = false,

                QuestionId = 23
            },

            // Question 24
            new PromptModel
            {
                Id = 70,
                Prompt = "Utnyttjande av tekniska säkerhetshål",
                IsCorrect = false,

                QuestionId = 24
            },
            new PromptModel
            {
                Id = 71,
                Prompt = "Personlig manipulation för att få obehörig åtkomst till information",
                IsCorrect = true,

                QuestionId = 24
            },
            new PromptModel
            {
                Id = 72,
                Prompt = "Öppna dörrar med hjälp av fysisk kraft",
                IsCorrect = false,

                QuestionId = 24
            },

            // Question 25
            new PromptModel
            {
                Id = 73,
                Prompt = "Svara på alla misstänkta e-postmeddelanden för att bekräfta deras äkthet",
                IsCorrect = false,

                QuestionId = 25
            },
            new PromptModel
            {
                Id = 74,
                Prompt = "Ignorera och radera misstänkta e-postmeddelanden utan att klicka på länkar",
                IsCorrect = true,

                QuestionId = 25
            },
            new PromptModel
            {
                Id = 75,
                Prompt = "Överföra alla misstänkta e-postmeddelanden till kollegor för en andra åsikt",
                IsCorrect = false,

                QuestionId = 25
            },

            // Question 26
            new PromptModel
            {
                Id = 76,
                Prompt = "Alltid ge ut personlig information över telefon när någon frågar",
                IsCorrect = false,

                QuestionId = 26
            },
            new PromptModel
            {
                Id = 77,
                Prompt = "Kontrollera identiteten hos personen som ringer genom att ringa tillbaka till ett officiellt nummer",
                IsCorrect = true,

                QuestionId = 26
            },
            new PromptModel
            {
                Id = 78,
                Prompt = "Ignorera alla telefonsamtal från okända nummer",
                IsCorrect = false,

                QuestionId = 26
            },

            // Question 27
            new PromptModel
            {
                Id = 79,
                Prompt = "Samtalet kommer från ett nummer som du känner igen",
                IsCorrect = false,

                QuestionId = 27
            },
            new PromptModel
            {
                Id = 80,
                Prompt = "Den som ringer erbjuder en tidsbegränsad affär som verkar för bra för att vara sann",
                IsCorrect = true,

                QuestionId = 27
            },
            new PromptModel
            {
                Id = 81,
                Prompt = "Den som ringer begär inga personliga uppgifter",
                IsCorrect = false,

                QuestionId = 27
            },

            // Question 28
            new PromptModel
            {
                Id = 82,
                Prompt = "Omedelbart svara och tillhandahålla begärd information",
                IsCorrect = false,

                QuestionId = 28
            },
            new PromptModel
            {
                Id = 83,
                Prompt = "Verifiera begäran direkt med VD:n genom en separat kommunikationskanal",
                IsCorrect = true,

                QuestionId = 28
            },
            new PromptModel
            {
                Id = 84,
                Prompt = "Skicka informationen till hela företaget för att dubbelkolla autenticiteten",
                IsCorrect = false,

                QuestionId = 28
            },

            // Question 29
            new PromptModel
            {
                Id = 85,
                Prompt = "När du får ett erbjudande som kräver att du köper och skickar presentkort som betalning",
                IsCorrect = true,

                QuestionId = 29
            },
            new PromptModel
            {
                Id = 86,
                Prompt = "När en kollega personligen ber dig köpa ett presentkort för dem",
                IsCorrect = false,

                QuestionId = 29
            },
            new PromptModel
            {
                Id = 87,
                Prompt = "När du får en rabatt på presentkort som endast kan köpas genom direktlänkar i e-post",
                IsCorrect = false,

                QuestionId = 29
            },

            // Question 30
            new PromptModel
            {
                Id = 88,
                Prompt = "Virus behöver ett värdprogram för att spridas, maskar sprider sig självständigt, och trojaner döljer sig som legitima program",
                IsCorrect = true,

                QuestionId = 30
            },
            new PromptModel
            {
                Id = 89,
                Prompt = "Virus och maskar är skadliga, men trojaner är ofarliga",
                IsCorrect = false,

                QuestionId = 30
            },
            new PromptModel
            {
                Id = 90,
                Prompt = "Virus sprider sig via e-post, maskar via nätverk och trojaner kan inte sprida sig alls",
                IsCorrect = false,

                QuestionId = 30
            },

            // Question 31
            new PromptModel
            {
                Id = 91,
                Prompt = "Genom fysisk åtkomst till företagets servrar",
                IsCorrect = false,

                QuestionId = 31
            },
            new PromptModel
            {
                Id = 92,
                Prompt = "Användning av avancerad kryptering för att skydda data",
                IsCorrect = false,

                QuestionId = 31
            },
            new PromptModel
            {
                Id = 93,
                Prompt = "Utnyttjande av säkerhetshål i programvara eller system",
                IsCorrect = true,

                QuestionId = 31
            },

            // Question 32
            new PromptModel
            {
                Id = 94,
                Prompt = "Ökad nätverkstrafik under udda tider",
                IsCorrect = true,

                QuestionId = 32
            },
            new PromptModel
            {
                Id = 95,
                Prompt = "Alla filer är krypterade och oåtkomliga",
                IsCorrect = false,

                QuestionId = 32
            },
            new PromptModel
            {
                Id = 96,
                Prompt = "Snabbare internetanslutning än vanligt",
                IsCorrect = false,

                QuestionId = 32
            },

            // Question 33
            new PromptModel
            {
                Id = 97,
                Prompt = "Informera alla berörda parter och genomför en grundlig säkerhetsrevision",
                IsCorrect = true,

                QuestionId = 33
            },
            new PromptModel
            {
                Id = 98,
                Prompt = "Ignorera problemet och hoppas att det går över av sig självt",
                IsCorrect = false,

                QuestionId = 33
            },
            new PromptModel
            {
                Id = 99,
                Prompt = "Öka antalet lösenord användaren måste komma ihåg",
                IsCorrect = false,

                QuestionId = 33
            },

            // Question 34
            new PromptModel
            {
                Id = 100,
                Prompt = "Byt omedelbart lösenord och aktivera tvåfaktorsautentisering där det är möjligt",
                IsCorrect = true,

                QuestionId = 34
            },
            new PromptModel
            {
                Id = 101,
                Prompt = "Publicera informationen på sociala medier för att varna andra",
                IsCorrect = false,

                QuestionId = 34
            },
            new PromptModel
            {
                Id = 102,
                Prompt = "Använd samma lösenord igen för att se om hackaren ger upp",
                IsCorrect = false,

                QuestionId = 34
            },

            // Question 35
            new PromptModel
            {
                Id = 103,
                Prompt = "Social engineering, utnyttjande av programvarusårbarheter och phishing",
                IsCorrect = true,

                QuestionId = 35
            },
            new PromptModel
            {
                Id = 104,
                Prompt = "Annonsering av falska jobberbjudanden",
                IsCorrect = false,

                QuestionId = 35
            },
            new PromptModel
            {
                Id = 105,
                Prompt = "Skicka brev med skadlig programvara till företagets adress",
                IsCorrect = false,

                QuestionId = 35
            },

            // Question 36
            new PromptModel
            {
                Id = 106,
                Prompt = "Betala lösen direkt till angriparen för att återfå tillgång till filerna",
                IsCorrect = false,

                QuestionId = 36
            },
            new PromptModel
            {
                Id = 107,
                Prompt = "Regelbunden säkerhetskopiering av viktig data och användning av säkerhetsprogramvara",
                IsCorrect = true,

                QuestionId = 36
            },
            new PromptModel
            {
                Id = 108,
                Prompt = "Öppna alla e-postbilagor för att kontrollera om de innehåller utpressningsvirus",
                IsCorrect = false,

                QuestionId = 36
            },

            // Question 37
            new PromptModel
            {
                Id = 109,
                Prompt = "Lämna servrarna ouppdaterade för att undvika kompatibilitetsproblem",
                IsCorrect = false,

                QuestionId = 37
            },
            new PromptModel
            {
                Id = 110,
                Prompt = "Använd starka lösenord och regelbundna säkerhetsuppdateringar",
                IsCorrect = true,

                QuestionId = 37
            },
            new PromptModel
            {
                Id = 111,
                Prompt = "Inaktivera brandväggar för att förbättra nätverksprestandan",
                IsCorrect = false,

                QuestionId = 37
            },

            // Question 38
            new PromptModel
            {
                Id = 112,
                Prompt = "Fysiska intrång i datacenter",
                IsCorrect = false,

                QuestionId = 38
            },
            new PromptModel
            {
                Id = 113,
                Prompt = "Sociala medier-bedrägerier",
                IsCorrect = false,

                QuestionId = 38
            },
            new PromptModel
            {
                Id = 114,
                Prompt = "Ransomware och phishing-kampanjer",
                IsCorrect = true,

                QuestionId = 38
            },

            // Question 39
            new PromptModel
            {
                Id = 115,
                Prompt = "Avancerade krypteringsalgoritmer för att skydda deras egna data",
                IsCorrect = false,

                QuestionId = 39
            },
            new PromptModel
            {
                Id = 116,
                Prompt = "Malware, keyloggers och botnets för att infiltrera och kontrollera system",
                IsCorrect = true,

                QuestionId = 39
            },
            new PromptModel
            {
                Id = 117,
                Prompt = "Offentliga Wi-Fi-nätverk för att anonymt skicka e-post",
                IsCorrect = false,

                QuestionId = 39
            },

            // Question 40
            new PromptModel
            {
                Id = 121,
                Prompt = "De orsakades av fysiska säkerhetsbrister",
                IsCorrect = false,

                QuestionId = 40
            },
            new PromptModel
            {
                Id = 122,
                Prompt = "De utnyttjade sårbarheter i outdaterad programvara",
                IsCorrect = true,

                QuestionId = 40
            },
            new PromptModel
            {
                Id = 123,
                Prompt = "De var riktade mot specifika individer",
                IsCorrect = false,

                QuestionId = 40
            },

            // Question 41
            new PromptModel
            {
                Id = 124,
                Prompt = "Undvika användning av molntjänster helt och hållet",
                IsCorrect = false,

                QuestionId = 41
            },
            new PromptModel
            {
                Id = 125,
                Prompt = "Använda flerfaktorsautentisering och strikt åtkomstkontroll",
                IsCorrect = true,

                QuestionId = 41
            },
            new PromptModel
            {
                Id = 126,
                Prompt = "Lagra all känslig information lokalt på osäkrade enheter",
                IsCorrect = false,

                QuestionId = 41
            },

            // Question 42
            new PromptModel
            {
                Id = 127,
                Prompt = "Cyberkriminalitet",
                IsCorrect = false,

                QuestionId = 42
            },
            new PromptModel
            {
                Id = 128,
                Prompt = "Cyberspionage",
                IsCorrect = true,

                QuestionId = 42
            },
            new PromptModel
            {
                Id = 129,
                Prompt = "Cyberterrorism",
                IsCorrect = false,

                QuestionId = 42
            },

            // Question 43
            new PromptModel
            {
                Id = 130,
                Prompt = "Öka användningen av kryptering för all intern och extern kommunikation",
                IsCorrect = true,

                QuestionId = 43
            },
            new PromptModel
            {
                Id = 131,
                Prompt = "Förbjuda all användning av e-post och återgå till fysisk korrespondens",
                IsCorrect = false,

                QuestionId = 43
            },
            new PromptModel
            {
                Id = 132,
                Prompt = "Installera antivirusprogram på alla datorer",
                IsCorrect = false,

                QuestionId = 43
            },

            // Question 44
            new PromptModel
            {
                Id = 133,
                Prompt = "Genomföra strikta bakgrundskontroller av alla anställda",
                IsCorrect = false,

                QuestionId = 44
            },
            new PromptModel
            {
                Id = 134,
                Prompt = "Implementera ett omfattande program för beteendeanalys och anomalidetektering",
                IsCorrect = true,

                QuestionId = 44
            },
            new PromptModel
            {
                Id = 135,
                Prompt = "Begränsa internetanvändningen på arbetsplatsen till arbetsrelaterade aktiviteter",
                IsCorrect = false,

                QuestionId = 44
            },

            // Question 45
            new PromptModel
            {
                Id = 136,
                Prompt = "Genomföra regelbundna medvetenhetsträningar för alla anställda om cybersäkerhet",
                IsCorrect = false,

                QuestionId = 45
            },
            new PromptModel
            {
                Id = 137,
                Prompt = "Hålla all mjukvara och operativsystem uppdaterade med de senaste säkerhetspatcharna",
                IsCorrect = true,

                QuestionId = 45
            },
            new PromptModel
            {
                Id = 138,
                Prompt = "Endast använda egenutvecklad mjukvara för alla verksamhetsprocesser",
                IsCorrect = false,

                QuestionId = 45
            },

            // Question 46
            new PromptModel
            {
                Id = 139,
                Prompt = "Social ingenjörskonst",
                IsCorrect = false,

                QuestionId = 46
            },
            new PromptModel
            {
                Id = 140,
                Prompt = "Massövervakning",
                IsCorrect = false,

                QuestionId = 46
            },
            new PromptModel
            {
                Id = 141,
                Prompt = "Riktade cyberattacker",
                IsCorrect = true,

                QuestionId = 46
            },

            // Question 47
            new PromptModel
            {
                Id = 142,
                Prompt = "GDPR",
                IsCorrect = false,

                QuestionId = 47
            },
            new PromptModel
            {
                Id = 143,
                Prompt = "Säkerhetsskyddslagen",
                IsCorrect = true,

                QuestionId = 47
            },
            new PromptModel
            {
                Id = 144,
                Prompt = "IT-säkerhetslagen",
                IsCorrect = false,

                QuestionId = 47
            },

            // Question 48
            new PromptModel
            {
                Id = 145,
                Prompt = "Oberoende hackare",
                IsCorrect = false,

                QuestionId = 48
            },
            new PromptModel
            {
                Id = 146,
                Prompt = "Aktivistgrupper",
                IsCorrect = false,

                QuestionId = 48
            },
            new PromptModel
            {
                Id = 147,
                Prompt = "Statssponsrade hackers",
                IsCorrect = true,

                QuestionId = 48
            },

            // Question 49
            new PromptModel
            {
                Id = 148,
                Prompt = "Genom att ignorera all kontakt från utländska entiteter",
                IsCorrect = false,

                QuestionId = 49
            },
            new PromptModel
            {
                Id = 149,
                Prompt = "Upprätta starka interna säkerhetsprotokoll och utbildning i medvetenhet om spionage",
                IsCorrect = true,

                QuestionId = 49
            },
            new PromptModel
            {
                Id = 150,
                Prompt = "Använda endast krypterad kommunikation för alla affärstransaktioner",
                IsCorrect = false,

                QuestionId = 49
            },

            // Question 50
            new PromptModel
            {
                Id = 151,
                Prompt = "Plötslig ökning av nätverkstrafik och ovanliga systemloggar",
                IsCorrect = true,

                QuestionId = 50
            },
            new PromptModel
            {
                Id = 152,
                Prompt = "Förlust av anställda till konkurrerande företag",
                IsCorrect = false,

                QuestionId = 50
            },
            new PromptModel
            {
                Id = 153,
                Prompt = "Ökad försäljning och marknadsandelar",
                IsCorrect = false,

                QuestionId = 50
            },

            // Question 51
            new PromptModel
            {
                Id = 154,
                Prompt = "Genom att helt undvika sociala medier",
                IsCorrect = false,

                QuestionId = 51
            },
            new PromptModel
            {
                Id = 155,
                Prompt = "Stärka källkritik och sprida medvetenhet om falska nyheter",
                IsCorrect = true,

                QuestionId = 51
            },
            new PromptModel
            {
                Id = 156,
                Prompt = "Endast tillåta godkända nyhetskällor",
                IsCorrect = false,

                QuestionId = 51
            },

            // Question 52
            new PromptModel
            {
                Id = 157,
                Prompt = "Genom offensiva cyberoperationer mot andra länder",
                IsCorrect = false,

                QuestionId = 52
            },
            new PromptModel
            {
                Id = 158,
                Prompt = "Samarbeta nationellt och internationellt för informationsutbyte och förbättring av cybersäkerhet",
                IsCorrect = true,

                QuestionId = 52
            },
            new PromptModel
            {
                Id = 159,
                Prompt = "Fokusera endast på fysisk säkerhet",
                IsCorrect = false,

                QuestionId = 52
            },

            // Question 53
            new PromptModel
            {
                Id = 160,
                Prompt = "Ingen, eftersom 5G-teknologi endast berör mobilnätverksoperatörer",
                IsCorrect = false,

                QuestionId = 53
            },
            new PromptModel
            {
                Id = 161,
                Prompt = "En kritisk roll i att säkerställa att 5G-nätverk är säkra från cyberhot och spioneri",
                IsCorrect = true,

                QuestionId = 53
            },
            new PromptModel
            {
                Id = 162,
                Prompt = "Enbart fokuserad på prissättning och tillgänglighet av tjänster",
                IsCorrect = false,

                QuestionId = 53
            },

            // Question 54
            new PromptModel
            {
                Id = 166,
                Prompt = "Genom att isolera sig och endast fokusera på intern cybersäkerhet",
                IsCorrect = false,

                QuestionId = 54
            },
            new PromptModel
            {
                Id = 167,
                Prompt = "Internationellt informationsutbyte och gemensamma insatser för cybersäkerhet",
                IsCorrect = true,

                QuestionId = 54
            },
            new PromptModel
            {
                Id = 168,
                Prompt = "Begränsa användningen av internet globalt",
                IsCorrect = false,

                QuestionId = 54
            });
        }
    }
}



