public class EventInformation {
  public EventType messageInfo;
  public BeatDetection sender;

  public EventInformation (EventType _type, BeatDetection _detection) {
    this.messageInfo = _type;
    this.sender = _detection;
  }
}
