using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

public class TextSpacing : BaseMeshEffect
{
    //字间距属性
    public float _textSpacing;

    public float TextSpce
    {
        get
        {
            return _textSpacing;
        }
        set
        {
            _textSpacing = value;
        }
    }



    public override void ModifyMesh(VertexHelper vh)
    {
        if (!IsActive() || vh.currentVertCount == 0)
        {
            return;
        }
        List<UIVertex> vertexs = new List<UIVertex>();
        vh.GetUIVertexStream(vertexs);
        int indexCount = vh.currentIndexCount;
        UIVertex vt;
        for (int i = 6; i < indexCount; i++)
        {
            //第一个字不改变位置
            vt = vertexs[i];
            vt.position += new Vector3(_textSpacing * (i / 6), 0, 0);
            vertexs[i] = vt;
            //注意点和索引的对应关系
            if (i % 6 <= 2)
            {
                vh.SetUIVertex(vt, (i / 6) * 4 + i % 6);
            }
            if (i % 6 == 4)
            {
                vh.SetUIVertex(vt, (i / 6) * 4 + i % 6 - 1);
            }
        }
    }
}
