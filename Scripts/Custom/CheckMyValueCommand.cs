using Server;
using Server.Commands;
using Server.Engines.XmlSpawner2;

public class CheckMyValueCommand
{
    public static void Initialize()
    {
        CommandSystem.Register("CheckMyValue", AccessLevel.Player, new CommandEventHandler(CheckMyValue_OnCommand));
    }

    [Usage("CheckMyValue")]
    [Description("Checks the player's custom value.")]
    public static void CheckMyValue_OnCommand(CommandEventArgs e)
    {
        Mobile m = e.Mobile;

        XmlCustomVariable xmlCustomValue = XmlAttach.FindAttachment(m, typeof(XmlCustomVariable)) as XmlCustomVariable;

        if (xmlCustomValue != null)
        {
            m.SendMessage($"Your custom value is: {xmlCustomValue.MyValue}.");
        }
        else
        {
            m.SendMessage("You do not have a custom value.");
        }
    }
}