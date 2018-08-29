using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calendar : MonoBehaviour {
  public static Calendar calendar;
  public static List<CalendarEvent> calendarEvents = new List<CalendarEvent>();
  public int year { get; set; }
  public int month { get; set; }
  public int day { get; set; }
  public string monthName { get; set; }

  private void Awake() {
    calendar = this;
  }
}