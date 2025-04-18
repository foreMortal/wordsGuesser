using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRowValidator
{
    public void ValidateRow(Color good, Color bad, Color neutral);
}
