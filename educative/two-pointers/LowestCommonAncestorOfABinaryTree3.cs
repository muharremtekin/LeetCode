public sealed class LowestCommonAncestorOfABinaryTree3
{
    // https://www.educative.io/interview-prep/coding/lowest-common-ancestor-of-a-binary-tree-iii

    // Adım 	a'nın Konumu	b'nin Konumu	 Ne Oldu?
    // 1	    6	            5	             Yolculuk başlıyor. İkisi de kendi başlangıç düğümünde.
    // 2	    4	            2	             İkisi de kendi ebeveynine (parent) çıktı.
    // 3	    2	            1	             İkisi de bir üst ebeveyne çıktı. Dikkat edersen aynı derinlikte değiller.
    // 4	    1	            null	         b kökü geçti ve boşluğa düştü. a ise şu an kökte (1).
    // 5	    null	        6	             Sihir başlıyor: b boşluğa düştüğü için p'nin başlangıcına (6) ışınlandı. a ise kökü geçip boşluğa düştü.
    // 6	    5	            4	             Sihir tamamlanıyor: a boşluğa düştüğü için q'nun başlangıcına (5) ışınlandı. b ise normal yoluna (yukarı) devam etti.
    // 7	    2	            2	             Eşleşme! a (5'in atası olan 2'ye çıktı), b (4'ün atası olan 2'ye çıktı). Döngü bitti.
    public EduTreeNode LowestCommonAncestor(EduTreeNode p, EduTreeNode q)
    {
        EduTreeNode a = p;
        EduTreeNode b = q;

        // İşaretçiler aynı düğümde buluşana kadar devam et
        while (a != b)
        {
            // (Distance Equalization)
            // Eğer a kökü geçerse (null), onu q'nun başlangıcına eşitle.
            // Aksi takdirde bir üst ataya (parent) git.
            a = a == null ? q : a.parent;

            // Aynı işlemi b için de yap ama çapraz olarak p'ye eşitle.
            b = b == null ? p : b.parent;
        }

        // a ve b aynı düğümde buluştuğunda o düğüm LCA'dır
        return a;
    }

}

public class EduTreeNode
{
    public int data { get; set; }
    public EduTreeNode left { get; set; }
    public EduTreeNode right { get; set; }
    public EduTreeNode parent { get; set; }


    public EduTreeNode(int data)
    {
        this.data = data;
        left = null;
        right = null;
        parent = null;
    }
}