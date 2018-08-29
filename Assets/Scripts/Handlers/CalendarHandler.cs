using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalendarHandler : MonoBehaviour {
  public static void handleCalendar () {
  }

  //Happens when calendar is loaded for the first time
  private void initializeCalendar () {
    Debug.Log(Calendar.calendarEvents.Count);
    Calendar.calendar.monthName = GlobalData.globalData.monthName;
    Calendar.calendar.year = GlobalData.globalData.years;
    Calendar.calendar.month = GlobalData.globalData.months;
    changeMonth();
  }

  public void nextMonth () {
    Calendar.calendar.month += 1;
    if (Calendar.calendar.month == 13) {
      Calendar.calendar.month = 1;
      Calendar.calendar.year += 1;
    }
    changeMonth();
  }

  public void prevMonth () {
    Calendar.calendar.month -= 1;
    if (Calendar.calendar.month == 0) {
      Calendar.calendar.month = 12;
      Calendar.calendar.year -= 1;
    }
    changeMonth();
  }

  //We want to handle all of the population of the events in here so that
  //when month is changed it happens implicitly
  //Don't really need to pass in the month since it can be found by getting
  //Calendar.calendar.month
  void changeMonth () {
    int month = Calendar.calendar.month - 1;
    string monthName = GlobalData.globalData.monthNameArray[month];
    GameObject.Find("Month").GetComponent<Text>().text = (
      monthName + ", " + Calendar.calendar.year
    );
    populateCalendar();
    //Iterate through events of this month and year and populate calendar with them
  }

  void populateCalendar () {
    //Clear the components of their text
    Debug.Log("CLEARING CALENDAR||GETTING READY FOR POPULATION");
    for (int i = 0; i < 28; i++) {
      GameObject.Find((i + 1).ToString()).GetComponentsInChildren<Text>()[1].text = ("");
    }

    Debug.Log("POPULATING CALENDAR");
    int month = Calendar.calendar.month;
    int year = Calendar.calendar.year;
    List<CalendarEvent> calendarEvents = Calendar.calendarEvents;

    for (int i = 0; i < calendarEvents.Count; i++) {
      string[] dateArray = calendarEvents[i].date.Split('/');
      int parsedMonth = System.Int32.Parse(dateArray[0]);
      int parsedYear = System.Int32.Parse(dateArray[2]);

      //If the event's year is '0' then it means it's yearly
      if (parsedYear == 0) {
        parsedYear = year;
      }

      if (parsedMonth == month && parsedYear == year) {
        GameObject.Find(dateArray[1]).GetComponentsInChildren<Text>()[1].text += (
          calendarEvents[i].title
        );
      }
    }
  }

  public static void createJobCE (ParsedJob job) {
    List<string> dates = new List<string>();
    dates = JobHandler.parseDate(job);
    //Create a new calendar event for each date in the job
    for (int i = 0; i < dates.Count; i++) {
      CalendarEvent cEvent = new CalendarEvent();
      cEvent.timeOfDay = job.timeOfDay;
      cEvent.type = job.type;
      cEvent.date = dates[i];
      cEvent.title = job.title;
      Calendar.calendarEvents.Add(cEvent);
    }

    //Parse through the data before setting it up in the calendar events
    //put dates into List<int> dates with the format dd/mm/yyyy
    //Create a new cEvent per date inside of List<int> dates

  }

  void Awake () {
    initializeCalendar();
  }
}