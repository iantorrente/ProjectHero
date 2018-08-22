
//Instead of passing a whole ParsedJob into here, just unload a ParsedJob's 
//stuff into this and load it into the calendar
public class CalendarEvent {
  public int date { get; set; }
  public string timeOfDay { get; set; }
  public string type { get; set; }
  public string title { get; set; }
}