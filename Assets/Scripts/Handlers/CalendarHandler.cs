using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalendarHandler : MonoBehaviour {
  public static void handleCalendar () {
  }

  //Happens when calendar is loaded for the first time
  private void initializeCalendar () {
    Debug.Log(Calendar.calendar.calendarEvents.Count);
    Calendar.calendar.monthName = GlobalData.globalData.monthName;
    Calendar.calendar.year = GlobalData.globalData.years;
    Calendar.calendar.month = GlobalData.globalData.months;
    changeMonth(Calendar.calendar.month);
    //For the current month, iterate through the data and see if
    //there are any events. If so then while there are, add them
    //to the calendar
  }

  public void nextMonth () {
    Calendar.calendar.month += 1;
    if (Calendar.calendar.month == 12) {
      Calendar.calendar.month = 0;
      Calendar.calendar.year += 1;
    }
    changeMonth(Calendar.calendar.month);
  }

  public void prevMonth () {
    Calendar.calendar.month -= 1;
    if (Calendar.calendar.month == -1) {
      Calendar.calendar.month = 11;
      Calendar.calendar.year -= 1;
    }
    changeMonth(Calendar.calendar.month);
  }

  //We want to handle all of the population of the events in here so that
  //when month is changed it happens implicitly
  void changeMonth (int month) {
    string monthName = GlobalData.globalData.monthNameArray[month];
    GameObject.Find("Month").GetComponent<Text>().text = (
      monthName + ", " + Calendar.calendar.year
    );
    //Iterate through events of this month and year and populate calendar with them
  }

  public static void createJobCE (ParsedJob job) {
    CalendarEvent cEvent = new CalendarEvent();
    List<int> dates = new List<int>();
    dates = JobHandler.parseDate(job);

    //Create a new calendar event for each date in the job
    for (int i = 0; i < dates.Count; i++) {
      cEvent.timeOfDay = job.timeOfDay;
      cEvent.timeOfDay = job.timeOfDay;
      cEvent.type = job.type;
      cEvent.date = dates[i];
      cEvent.title = job.title;
    }

    //Parse through the data before setting it up in the calendar events
    //put dates into List<int> dates with the format dd/mm/yyyy
    //Create a new cEvent per date inside of List<int> dates

    Calendar.calendar.calendarEvents.Add(cEvent);
  }

  void Awake () {
    initializeCalendar();
  }
}