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
        Random random = new Random();
        id = random.Next(10000, 100000);
        this.title = title;
        playCount = 0;
    }

    public void increasePlayCount(int playCount)
    {
        this.playCount += playCount;
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
        this.uploadedVideo.Add(video);
    }

    public void printAllVideo()
    {
        Console.WriteLine("User: " + username);
       for(int i = 0; i < this.uploadedVideo.Count; i++)
        {
            Console.WriteLine("Video " + (i +1) + " judul: " + uploadedVideo[i].getTitle());
        }
    }
}

class Utama
{
    public static void Main()
    {
        SayaTubeVideo sayaTubeVideo = new SayaTubeVideo("Tutorial Design By Contract – [ADAM RAFIF FAQIH]");
        SayaTubeVideo tutor2 = new SayaTubeVideo("Tutorial – [ADAM RAFIF FAQIH]");
        SayaTubeUser sayaTubeUser = new SayaTubeUser("Adam");
        sayaTubeVideo.increasePlayCount(100);
        tutor2.increasePlayCount(100);
        sayaTubeVideo.printVideoDetails();
        sayaTubeUser.addVideo(sayaTubeVideo);
        sayaTubeUser.addVideo(tutor2);
        Console.WriteLine(sayaTubeUser.getTotalVideoPlayCount());
        sayaTubeUser.printAllVideo();


    }
}