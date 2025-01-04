using System.Collections.Generic;
using System.Linq;
using WebApplication3.Models;

public class MovieService
{
    private static List<Movie> movies = new List<Movie>
    {
        new Movie { Id = 1, Title = "Incepcja", ImageUrl = "/images/inception.jpg", Description = "Historia Dominicka Cobba, mistrza złodziei, który potrafi kraść sekrety z umysłów ludzi poprzez ich sny. Misja, którą podejmuje, może zmienić jego życie na zawsze." },
        new Movie { Id = 2, Title = "Matrix", ImageUrl = "/images/matrix.jpg", Description = "Neo, młody programista komputerowy, odkrywa, że rzeczywistość, którą zna, jest symulacją kontrolowaną przez maszyny. Wkracza w świat rebeliantów walczących o wolność ludzkości." },
        new Movie { Id = 3, Title = "Interstellar", ImageUrl = "/images/interstellar.jpg", Description = "Grupa astronautów wyrusza w podróż przez tunel czasoprzestrzenny, aby znaleźć nowy dom dla ludzkości na odległej planecie, gdy Ziemia staje się niezamieszkiwalna." },
        new Movie { Id = 4, Title = "Mroczny rycerz", ImageUrl = "/images/dark_knight.jpg", Description = "Batman staje w obliczu swojego największego przeciwnika - Jokera, który sieje chaos w Gotham City, zmuszając bohatera do podjęcia trudnych decyzji." },
        new Movie { Id = 5, Title = "Forrest Gump", ImageUrl = "/images/forrest_gump.jpg", Description = "Historia prostodusznego mężczyzny, który staje się świadkiem kluczowych wydarzeń XX wieku, nie zdając sobie sprawy z ich znaczenia." },
        new Movie { Id = 6, Title = "Skazani na Shawshank", ImageUrl = "/images/shawshank.jpg", Description = "Andy Dufresne, skazany na dożywocie za morderstwo, którego nie popełnił, odkrywa wartość przyjaźni i nadziei za murami więzienia." },
        new Movie { Id = 7, Title = "Pulp Fiction", ImageUrl = "/images/pulp_fiction.jpg", Description = "Splątane historie gangstera, jego żony, boksera i dwóch drobnych przestępców tworzą surrealistyczny obraz życia w Los Angeles." },
        new Movie { Id = 8, Title = "Ojciec chrzestny", ImageUrl = "/images/godfather.jpg", Description = "Epicka saga rodziny mafijnej Corleone, ukazująca ich wpływ na świat przestępczy oraz osobiste dramaty jej członków." },
        new Movie { Id = 9, Title = "Władca Pierścieni: Powrót króla", ImageUrl = "/images/lotr_return.jpg", Description = "Frodo i Sam kontynuują swoją podróż do Mordoru, aby zniszczyć pierścień, podczas gdy ich przyjaciele walczą o przetrwanie Śródziemia." },
        new Movie { Id = 10, Title = "Avengers", ImageUrl = "/images/avengers.jpg", Description = "Grupa superbohaterów musi połączyć siły, aby pokonać Lokiego, który planuje przejąć kontrolę nad Ziemią." },
        new Movie { Id = 11, Title = "Titanic", ImageUrl = "/images/titanic.jpg", Description = "Romans pomiędzy Jackiem i Rose na pokładzie słynnego Titanica, który zmierza ku tragicznej katastrofie." },
        new Movie { Id = 12, Title = "Gladiator", ImageUrl = "/images/gladiator.jpg", Description = "Maximus, były generał, zostaje gladiatorem, który walczy o zemstę na cesarzu odpowiedzialnym za śmierć jego rodziny." },
        new Movie { Id = 13, Title = "Gwiezdne wojny: Nowa nadzieja", ImageUrl = "/images/star_wars.jpg", Description = "Luke Skywalker dołącza do Rebelii, aby uratować księżniczkę Leię i pokonać potężne Imperium." },
        new Movie { Id = 14, Title = "Park Jurajski", ImageUrl = "/images/jurassic_park.jpg", Description = "Eksperymentalny park pełen żywych dinozaurów zamienia się w chaos, gdy systemy bezpieczeństwa zawodzą." },
        new Movie { Id = 15, Title = "Król Lew", ImageUrl = "/images/lion_king.jpg", Description = "Młody lew Simba przechodzi trudną drogę, aby odzyskać swoje miejsce jako król sawanny." },
        new Movie { Id = 16, Title = "Podziemny krąg", ImageUrl = "/images/fight_club.jpg", Description = "Anonimowy mężczyzna zakłada tajny klub walki, który szybko wymyka się spod kontroli." },
        new Movie { Id = 17, Title = "Avatar", ImageUrl = "/images/avatar.jpg", Description = "Jake Sully, sparaliżowany żołnierz, odkrywa piękno i niebezpieczeństwo Pandory, wcielając się w awatara." },
        new Movie { Id = 18, Title = "Milczenie owiec", ImageUrl = "/images/silence_lambs.jpg", Description = "Clarice Starling korzysta z pomocy więźnia Hannibala Lectera, aby schwytać seryjnego mordercę." },
        new Movie { Id = 19, Title = "Lista Schindlera", ImageUrl = "/images/schindler.jpg", Description = "Prawdziwa historia Oskara Schindlera, który uratował setki Żydów podczas II wojny światowej." },
        new Movie { Id = 20, Title = "Wilk z Wall Street", ImageUrl = "/images/wolf_wall.jpg", Description = "Ekscentryczny broker Jordan Belfort opowiada o wzlotach i upadkach swojej kariery na Wall Street." },
        new Movie { Id = 21, Title = "Avengers: Koniec gry", ImageUrl = "/images/endgame.jpg", Description = "Ostateczna walka Avengersów z Thanosem, aby przywrócić równowagę we wszechświecie." },
        new Movie { Id = 22, Title = "Toy Story", ImageUrl = "/images/toy_story.jpg", Description = "Pełna ciepła opowieść o życiu zabawek, które ożywają, gdy ludzie nie patrzą. Woody i Buzz Astral uczą się, co znaczy prawdziwa przyjaźń, podczas emocjonujących przygód." },
        new Movie { Id = 23, Title = "Coco", ImageUrl = "/images/coco.jpg", Description = "Miguel, młody chłopiec marzący o zostaniu muzykiem, trafia do magicznego świata zmarłych, gdzie odkrywa sekrety swojej rodziny i piękno tradycji." },
        new Movie { Id = 24, Title = "The Social Network", ImageUrl = "/images/social_network.jpg", Description = "Zajrzyj za kulisy powstania Facebooka, gdzie ambicje, geniusz i zdrady prowadzą do stworzenia jednego z największych serwisów społecznościowych na świecie." },
        new Movie { Id = 25, Title = "Kraina lodu", ImageUrl = "/images/frozen.jpg", Description = "Anna wyrusza na niebezpieczną wyprawę, aby odnaleźć swoją siostrę Elsę, która przypadkowo zamroziła ich królestwo w wiecznej zimie. Pełna magii opowieść o rodzinie i miłości." },
        new Movie { Id = 26, Title = "Czarna Pantera", ImageUrl = "/images/black_panther.jpg", Description = "T'Challa, nowy król Wakandy, musi zmierzyć się z zagrożeniem wewnętrznym i zewnętrznym, aby chronić swoje królestwo oraz jego zaawansowaną technologię." },
        new Movie { Id = 27, Title = "Doktor Strange", ImageUrl = "/images/doctor_strange.jpg", Description = "Stephen Strange, utalentowany chirurg, po tragicznym wypadku odkrywa świat mistycznych sztuk i staje się potężnym czarodziejem." },
        new Movie { Id = 28, Title = "Strażnicy Galaktyki", ImageUrl = "/images/guardians.jpg", Description = "Zespół wyrzutków z różnych zakątków galaktyki jednoczy się, aby powstrzymać potężnego złoczyńcę przed zdobyciem wszechmocnego artefaktu." },
        new Movie { Id = 29, Title = "Iron Man", ImageUrl = "/images/iron_man.jpg", Description = "Tony Stark, genialny wynalazca i miliarder, tworzy zaawansowaną zbroję, aby walczyć z przestępczością i ochronić świat." },
        new Movie { Id = 30, Title = "Kapitan Ameryka: Zimowy żołnierz", ImageUrl = "/images/captain_america.jpg", Description = "Kapitan Ameryka odkrywa spisek wewnątrz S.H.I.E.L.D. i musi stawić czoła tajemniczemu Zimowemu Żołnierzowi." },
        new Movie { Id = 31, Title = "Spider-Man: Homecoming", ImageUrl = "/images/spiderman.jpg", Description = "Peter Parker, młody superbohater, uczy się, jak łączyć życie licealisty z obowiązkami Spider-Mana, walcząc z nowym wrogiem." },
        new Movie { Id = 32, Title = "Thor: Ragnarok", ImageUrl = "/images/thor.jpg", Description = "Thor musi uwolnić się z kosmicznego więzienia i powstrzymać Ragnarok - zagładę Asgardu, z pomocą nieoczekiwanych sojuszników." },
        new Movie { Id = 33, Title = "Wonder Woman", ImageUrl = "/images/wonder_woman.jpg", Description = "Diana Prince opuszcza swoją wyspę Amazonek, aby pomóc światu w czasie I wojny światowej i odkryć swoje przeznaczenie jako Wonder Woman." },
        new Movie { Id = 34, Title = "Deadpool", ImageUrl = "/images/deadpool.jpg", Description = "Sarkastyczny najemnik z nadludzką zdolnością regeneracji wyrusza na misję zemsty na człowieku, który go oszpecił." },
        new Movie { Id = 35, Title = "Logan", ImageUrl = "/images/logan.jpg", Description = "Logan, starzejący się Wolverine, podejmuje ostatnią misję, aby ochronić młodą mutantkę przed bezwzględnym wrogiem." },
        new Movie { Id = 36, Title = "Joker", ImageUrl = "/images/joker.jpg", Description = "Przełomowa opowieść o początkach Jokera, ukazująca jego drogę od marginalizacji społecznej do stania się ikoną chaosu." },
        new Movie { Id = 37, Title = "Batman", ImageUrl = "/images/batman.jpg", Description = "Młody Bruce Wayne rozpoczyna swoją misję jako mroczny rycerz Gotham, walcząc z przestępcami i budując swoją legendę." },
        new Movie { Id = 38, Title = "Shazam!", ImageUrl = "/images/shazam.jpg", Description = "Billy Batson, nastolatek, zyskuje zdolność przemiany w dorosłego superbohatera dzięki magicznemu słowu 'Shazam'." },
        new Movie { Id = 39, Title = "Aquaman", ImageUrl = "/images/aquaman.jpg", Description = "Arthur Curry odkrywa swoje dziedzictwo jako władca Atlantydy i wyrusza na misję zjednoczenia podwodnych królestw." },
        new Movie { Id = 40, Title = "Flash", ImageUrl = "/images/flash.jpg", Description = "Barry Allen, najszybszy człowiek na świecie, używa swoich mocy, aby naprawić przeszłość i uratować przyszłość." },
        new Movie { Id = 41, Title = "Fantastyczne zwierzęta", ImageUrl = "/images/fantastic_beasts.jpg", Description = "Newt Scamander przybywa do Nowego Jorku z magicznymi stworzeniami, które przypadkowo zostają uwolnione." },
        new Movie { Id = 42, Title = "Diuna", ImageUrl = "/images/dune.jpg", Description = "Paul Atreides wyrusza na pustynną planetę Arrakis, aby odkryć swoje przeznaczenie i walczyć o przetrwanie swojego rodu." },
        new Movie { Id = 43, Title = "Blade Runner 2049", ImageUrl = "/images/blade_runner.jpg", Description = "Nowy łowca androidów odkrywa długo skrywany sekret, który może zmienić oblicze przyszłości ludzkości." },
        new Movie { Id = 44, Title = "Irlandczyk", ImageUrl = "/images/irishman.jpg", Description = "Historia Franka Sheerana, płatnego mordercy, który wspomina swoje życie pełne zdrady i lojalności w świecie mafii." },
        new Movie { Id = 45, Title = "Parasite", ImageUrl = "/images/parasite.jpg", Description = "Rodzina z marginesu społecznego wkrada się w życie bogatej rodziny, co prowadzi do serii nieprzewidywalnych wydarzeń." },
        new Movie { Id = 46, Title = "1917", ImageUrl = "/images/1917.jpg", Description = "Dwóch żołnierzy otrzymuje misję przekazania wiadomości, która może uratować setki istnień podczas I wojny światowej." },
        new Movie { Id = 47, Title = "Na noże", ImageUrl = "/images/knives_out.jpg", Description = "Ekscentryczny detektyw bada tajemnicze morderstwo patriarchy bogatej rodziny, odkrywając złożone relacje między jej członkami." },
        new Movie { Id = 48, Title = "Tenet", ImageUrl = "/images/tenet.jpg", Description = "Agent tajnej organizacji używa technologii odwracania czasu, aby zapobiec globalnej katastrofie." },
        new Movie { Id = 49, Title = "Co w duszy gra", ImageUrl = "/images/soul.jpg", Description = "Joe Gardner, nauczyciel muzyki, trafia do zaświatów, gdzie odkrywa prawdziwy sens życia i swojej pasji." },
        new Movie { Id = 50, Title = "Ratatuj", ImageUrl = "/images/ratatouille.jpg", Description = "Remy, szczur z talentem kulinarnym, nawiązuje niezwykłą współpracę z młodym kucharzem w eleganckiej paryskiej restauracji." },

    };

    public List<Movie> GetAllMovies()
    {
        return movies;
    }

    public Movie GetMovieById(int id)
    {
        return movies.FirstOrDefault(m => m.Id == id);
    }

    internal object GetMovieById(object id)
    {
        throw new NotImplementedException();
    }
}