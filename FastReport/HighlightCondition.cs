using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.ComponentModel;
using System.Drawing.Design;
using FastReport.TypeEditors;
using FastReport.Utils;

namespace FastReport
{
  /// <summary>
  /// Represents a single highlight condition used by the <see cref="TextObject.Highlight"/> property
  /// of the <see cref="TextObject"/>.
  /// </summary>
  public class HighlightCondition : IFRSerializable
  {
    #region Fields
    private string FExpression;
    private FillBase FFill;
    private FillBase FTextFill;
    private Font FFont;
    private bool FVisible;
    private bool FApplyFill;
    private bool FApplyTextFill;
    private bool FApplyFont;
    #endregion

    #region Properties
    /// <summary>
    /// Gets or sets a highlight expression.
    /// </summary>
    /// <remarks>
    /// This property can contain any valid boolean expression. If value of this expression is <b>true</b>,
    /// the fill and font settings will be applied to the <b>TextObject</b>.
    /// </remarks>
    [Editor(typeof(ExpressionEditor), typeof(UITypeEditor))]
    public string Expression
    {
      get { return FExpression; }
      set { FExpression = value; }
    }

    /// <summary>
    /// Gets or sets a fill.
    /// </summary>
    /// <remarks>
    /// If value of the <see cref="Expression"/> is <b>true</b>, the fill will be applied 
    /// to the <b>TextObject</b>.
    /// </remarks>
    public FillBase Fill
    {
      get { return FFill; }
      set { FFill = value; }
    }

    /// <summary>
    /// Gets or sets a text fill.
    /// </summary>
    /// <remarks>
    /// If value of the <see cref="Expression"/> is <b>true</b>, the text fill will be applied 
    /// to the <b>TextObject</b>.
    /// </remarks>
    public FillBase TextFill
    {
      get { return FTextFill; }
      set { FTextFill = value; }
    }

    /// <summary>
    /// Gets or sets a font.
    /// </summary>
    /// <remarks>
    /// If value of the <see cref="Expression"/> is <b>true</b>, the font style will be applied 
    /// to the <b>TextObject</b>.
    /// </remarks>
    public Font Font
    {
      get { return FFont; }
      set { FFont = value; }
    }

    /// <summary>
    /// Gets or sets the visibility flag.
    /// </summary>
    /// <remarks>
    /// If this property is set to <b>false</b>, the Text object will be hidden if the
    /// condition is met.
    /// </remarks>
    public bool Visible
    {
      get { return FVisible; }
      set { FVisible = value; }
    }
    
    /// <summary>
    /// Gets or sets a value determines that the fill must be applied.
    /// </summary>
    public bool ApplyFill
    {
      get { return FApplyFill; }
      set { FApplyFill = value; }
    }

    /// <summary>
    /// Gets or sets a value determines that the text fill must be applied.
    /// </summary>
    public bool ApplyTextFill
    {
      get { return FApplyTextFill; }
      set { FApplyTextFill = value; }
    }

    /// <summary>
    /// Gets or sets a value determines that the font must be applied.
    /// </summary>
    public bool ApplyFont
    {
      get { return FApplyFont; }
      set { FApplyFont = value; }
    }
    #endregion

    #region Public Methods
    /// <summary>
    /// Serializes the class.
    /// </summary>
    /// <param name="writer">Writer object.</param>
    /// <remarks>
    /// This method is for internal use only.
    /// </remarks>
    public void Serialize(FRWriter writer)
    {
      HighlightCondition c = writer.DiffObject as HighlightCondition;
      writer.ItemName = "Condition";
      if (Expression != c.Expression)
        writer.WriteStr("Expression", Expression);
      Fill.Serialize(writer, "Fill", c.Fill);
      TextFill.Serialize(writer, "TextFill", c.TextFill);
      if (!Font.Equals(c.Font))
        writer.WriteValue("Font", Font);
      if (Visible != c.Visible)
        writer.WriteBool("Visible", Visible);
      if (ApplyFill != c.ApplyFill)
        writer.WriteBool("ApplyFill", ApplyFill);
      if (ApplyTextFill != c.ApplyTextFill)
        writer.WriteBool("ApplyTextFill", ApplyTextFill);
      if (ApplyFont != c.ApplyFont)
        writer.WriteBool("ApplyFont", ApplyFont);
    }

    /// <summary>
    /// Deserializes the class.
    /// </summary>
    /// <param name="reader">Reader object.</param>
    /// <remarks>
    /// This method is for internal use only.
    /// </remarks>
    public void Deserialize(FRReader reader)
    {
      reader.ReadProperties(this);
    }

    /// <summary>
    /// Assigns values from another source.
    /// </summary>
    /// <param name="source">Source to assign from.</param>
    public void Assign(HighlightCondition source)
    {
      Expression = source.Expression;
      Fill = source.Fill.Clone();
      TextFill = source.TextFill.Clone();
      Font = source.Font;
      Visible = source.Visible;
      ApplyFill = source.ApplyFill;
      ApplyTextFill = source.ApplyTextFill;
      ApplyFont = source.ApplyFont;
    }

    /// <summary>
    /// Creates exact copy of this condition.
    /// </summary>
    /// <returns>Copy of this condition.</returns>
    public HighlightCondition Clone()
    {
      HighlightCondition result = new HighlightCondition();
      result.Assign(this);
      return result;
    }

    /// <inheritdoc/>
    public override bool Equals(object obj)
    {
      HighlightCondition c = obj as HighlightCondition;
      return c != null && Expression == c.Expression && Fill.Equals(c.Fill) &&
        TextFill.Equals(c.TextFill) && Font.Equals(c.Font) && Visible == c.Visible &&
        ApplyFill == c.ApplyFill && ApplyTextFill == c.ApplyTextFill && ApplyFont == c.ApplyFont;
    }

    /// <inheritdoc/>
    public override int GetHashCode()
    {
      return base.GetHashCode();
    }
    #endregion

    /// <summary>
    /// Initializes a new instance of the <see cref="HighlightCondition"/> class with default settings.
    /// </summary>
    public HighlightCondition()
    {
      Expression = "";
      Fill = new SolidFill();
      TextFill = new SolidFill(Color.Red);
      Font = Config.DesignerSettings.DefaultFont;
      Visible = true;
      ApplyFill = false;
      ApplyTextFill = true;
      ApplyFont = false;
    }
  }
}
