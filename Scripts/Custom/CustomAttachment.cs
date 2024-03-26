using Server;
using Server.Engines.XmlSpawner2;

public class XmlCustomVariable : XmlAttachment
{
    private int myValue;

    [CommandProperty(AccessLevel.GameMaster)]
    public int MyValue
    {
        get => myValue;
        set { myValue = value; }
    }

    public XmlCustomVariable() { }

    public XmlCustomVariable(int value)
    {
        myValue = value;
    }

    // 이 메소드는 XmlAttachment 데이터를 저장하는 데 사용됩니다.
    public override void Serialize(GenericWriter writer)
    {
        base.Serialize(writer);
        writer.Write(0); // Version
        writer.Write(myValue);
    }

    // 이 메소드는 XmlAttachment 데이터를 불러오는 데 사용됩니다.
    public override void Deserialize(GenericReader reader)
    {
        base.Deserialize(reader);
        int version = reader.ReadInt();
        myValue = reader.ReadInt();
    }
}