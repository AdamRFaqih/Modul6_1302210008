
using System.Diagnostics;

class SayaTubeVideo
{
    private int id;
    private string title;
    private int playCount;


    public int getPlayCount() { 
        return playCount; 
    }

    public SayaTubeVideo(string title)
    {
        ErrorHandling errorHandling = new ErrorHandling();
        errorHandling.isVideoTitleNull(title);
        errorHandling.isVideoTitleTooLong(title);
        
        Debug.Assert(string.IsNullOrEmpty(title), "Judul Null");
        Debug.Assert(title.Length > 200, "Judul kepanjangan");
        Random random = new Random();
        id = random.Next(10000, 100000);
        this.title = title;
        playCount = 0;
    }

    public void increasePlayCount(int playCount)
    {
        ErrorHandling errorHandling = new ErrorHandling();
        errorHandling.isInputPlayCountMax(playCount);
        errorHandling.isInputPlayCountNegative(playCount);
        
        Debug.Assert(playCount > 25000000, "Masukan kebanyakan");
        Debug.Assert(playCount < 0, "Masukan Negatif");

        checked
        {
            this.playCount += playCount;
        }
    }

    public string getTitle()
    {
        return title;
    }

    public void printVideoDetails()
    {
        Console.WriteLine("Judul Video: " + "[" + id + "]" + title);
        Console.WriteLine("Views: " + playCount);
    }

}

class SayaTubeUser
{
    private int id;
    private List<SayaTubeVideo> uploadedVideo;
    public string username;


    public SayaTubeUser(string username)
    {
        ErrorHandling errorHandling = new ErrorHandling();
        errorHandling.isUsernameNull(username);
        errorHandling.isUsernameLong(username);
        
        Debug.Assert(username != null, "Username NULL");
        Debug.Assert(username.Length > 100, "Username kepanjangan");
        
        Random random = new Random();
        id = random.Next(10000, 100000);
        this.username = username;
        this.uploadedVideo = new List<SayaTubeVideo>();
    }

    public int getTotalVideoPlayCount()
    {
        int total = 0;
        foreach(SayaTubeVideo video in this.uploadedVideo)
        {
            total += video.getPlayCount();
        }

        return total;
    }

    public void addVideo(SayaTubeVideo video)
    {
        ErrorHandling errorHandling = new ErrorHandling();
        errorHandling.isVideoNull(video);
        errorHandling.isVideoViewsMax(video);
        
        Debug.Assert(!this.uploadedVideo.Contains(video), "Video kosong");
        Debug.Assert(video.getPlayCount() >= int.MaxValue, "Views Max");
        this.uploadedVideo.Add(video);
    }

    public void printAllVideo()
    {
        Console.WriteLine("User: " + username);
       for(int i = 0; i < this.uploadedVideo.Count; i++)
        {
            if(i > 7)
            {
                break;
            }
            Console.WriteLine("Video " + (i +1) + " judul: " + uploadedVideo[i].getTitle());
        }
    }


}

class ErrorHandling
{
    public void isVideoTitleNull(string title)
    {
        if (String.IsNullOrEmpty(title))
        {
            throw new ArgumentNullException("INPUT JUDUL JANGAN NULL");
        }
    }

    public void isVideoTitleTooLong(string title)
    {
        if (title.Length > 200)
        {
            throw new ArgumentNullException("INPUT JUDUL MELEBIHI 200 KARAKTER");
        }
    }

    public void isInputPlayCountMax(int masuk)
    {
        if (masuk > 25000000)
        {
            throw new OverflowException("INPUT PLAYCOUNT LEBIH DARI 25 JUTA");
        }
    }

    public void isInputPlayCountNegative(int masuk)
    {
        if (masuk < 0)
        {
            throw new OverflowException("INPUT PLAYCOUNT JANGAN NEGATIVE");
        }
    }

    public void isUsernameNull(string username)
    {
        if (String.IsNullOrEmpty(username))
        {
            throw new ArgumentNullException("INPUT USERNAME JANGAN NULL");
        }
    }

    public void isUsernameLong(string username)
    {
        if (username.Length > 100)
        {
            throw new ArgumentNullException("INPUT USERNAME MELEBIHI 100 KARAKTER");
        }
    }

    public void isVideoNull(SayaTubeVideo video)
    {
        if (video == null)
        {
            throw new ArgumentNullException("TIDAK ADA VIDEO YANG DITAMBAHKAN");
        }
    }

    public void isVideoViewsMax(SayaTubeVideo video)
    {
        if (video.getPlayCount() >= int.MaxValue)
        {
            throw new ArgumentNullException("VIDEO YANG DITAMBAHKAN MAX VIEWS");
        }
    }
}

class Utama
{
    public static void Main()
    {
        //SayaTubeVideo sayaTubeVideo = new SayaTubeVideo("Tutorial Design By Contract – [ADAM RAFIF FAQIH]");
        //SayaTubeVideo tutor2 = new SayaTubeVideo("Tutorial – [ADAM RAFIF FAQIH]");
        //SayaTubeUser sayaTubeUser = new SayaTubeUser("Adam");
        //sayaTubeVideo.increasePlayCount(100);
        //tutor2.increasePlayCount(100);
        //sayaTubeVideo.printVideoDetails();
        //sayaTubeUser.addVideo(sayaTubeVideo);
        //sayaTubeUser.addVideo(tutor2);
        //Console.WriteLine(sayaTubeUser.getTotalVideoPlayCount());
        //sayaTubeUser.printAllVideo();


        try
        {
            SayaTubeUser adam = new SayaTubeUser("ADAM");
            SayaTubeVideo aot1 = new SayaTubeVideo("Attack on Titan Season 1");
            SayaTubeVideo aot2 = new SayaTubeVideo("Attack on Titan Season 2");
            SayaTubeVideo aot3 = new SayaTubeVideo("Attack on Titan Season 3");
            SayaTubeVideo aot4 = new SayaTubeVideo("Attack on Titan Season 4 part 1");
            SayaTubeVideo aot5 = new SayaTubeVideo("Attack on Titan Season 4 part 2");
            SayaTubeVideo aot6 = new SayaTubeVideo("Attack on Titan Season 4 part 3 bagian 1");
            SayaTubeVideo aot7 = new SayaTubeVideo("Attack on Titan Season 4 part 3 bagian 2");
            SayaTubeVideo ironMan = new SayaTubeVideo("iron Man");
            SayaTubeVideo ironMan2 = new SayaTubeVideo("iron Man 2");
            adam.addVideo(aot1);
            adam.addVideo(aot2);
            adam.addVideo(aot3);
            adam.addVideo(aot4);
            adam.addVideo(aot5);
            adam.addVideo(aot6);
            adam.addVideo(aot7);
            adam.addVideo(ironMan);
            adam.addVideo(ironMan2);
            adam.printAllVideo();
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

    }
}