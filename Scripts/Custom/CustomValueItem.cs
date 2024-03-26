using Server; // Server 네임스페이스 추가
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

public class AItem : Item
{
    [Constructable]
    public AItem() : base(0x1AE7) // 아이템의 그래픽 ID 설정
    {
        Movable = true;
        Hue = 0x489; // 아이템 색상 설정 (옵션)
    }

    public override void OnDoubleClick(Mobile from)
    {
        base.OnDoubleClick(from);

        // XmlCustomVariable 찾기 또는 생성하기
        XmlCustomVariable myVar = XmlAttach.FindAttachment(from, typeof(XmlCustomVariable)) as XmlCustomVariable;
        if (myVar == null)
        {
            myVar = new XmlCustomVariable(0);
            XmlAttach.AttachTo(from, myVar);
        }

        myVar.MyValue += 100; // 값 100 증가
        from.SendMessage($"Your value has been increased to {myVar.MyValue}.");
    }

    public AItem(Serial serial) : base(serial)
    {
    }

    public override void Serialize(GenericWriter writer)
    {
        base.Serialize(writer);
        writer.Write((int)0); // version
    }

    public override void Deserialize(GenericReader reader)
    {
        base.Deserialize(reader);
        int version = reader.ReadInt();
    }
}