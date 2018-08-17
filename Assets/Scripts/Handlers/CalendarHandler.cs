using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalendarHandler : MonoBehaviour {
  public static void handleCalendar () {
  }

  //Populate the calendar with stuff.
  private static void initializeCalendar () {
    GameObject.Find("Month").GetComponent<Text>().text = (
      GlobalData.globalData.monthName
    );
    //For the current month, iterate through the data and see if
    //there are any events. If so then while there are, add them
    //to the calendar
  }

  public static void nextMonth () {

  }

  public static void prevMonth () {

  }

  public static void createCalendarEvent (string title, string body, int date) {
    string eventEntry = (title + ": " + body);
    string[] calendarEvents = GlobalData.globalData.calendarEvents;
    LinkedList<string> dates = new LinkedList<string>(calendarEvents);
  }

  void Awake () {
    initializeCalendar();
  }
}