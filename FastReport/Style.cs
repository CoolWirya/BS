using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using FastReport.Utils;

namespace FastReport
{
  /// <summary>
  /// Represents a style.
  /// </summary>
  /// <remarks>
  /// <para>
  /// Style class holds border, fill, text fill and font settings. It can be applied to any report object of
  /// <see cref="ReportComponentBase"/> type.
  /// </para>
  /// <para>
  /// The <b>Report</b> object holds list of styles in its <see cref="Report.Styles"/> property. Each style has
  /// unique name. To apply a style to the report component, set its <see cref="ReportComponentBase.Style"/>
  /// property to the style name.
  /// </para>
  /// </remarks>
  public class Style : IFRSerializable
  {
    private string FName;
    private Border FBorder;
    private FillBase FFill;
    private FillBase FTextFill;
    private Font FFont;
    
    /// <summary>
    /// Gets or sets a name of the style.
    /// </summary>
    /// <remarks>
    /// Name must be unique.
    /// </remarks>
    public string Name
    {
      get { return FName; }
      set { FName = value; }
    }
    
    /// <summary>
    /// Gets or sets a border.
    /// </summary>
    public Border Border
    {
      get { return FBorder; }
      set { FBorder = value; }
    }
    
    /// <summary>
    /// Gets or sets a fill.
    /// </summary>
    public FillBase Fill
    {
      get { return FFill; }
      set { FFill = value; }
    }

    /// <summary>
    /// Gets or sets a text fill.
    /// </summary>
    public FillBase TextFill
    {
      get { return FTextFill; }
      set { FTextFill = value; }
    }

    /// <summary>
    /// Gets or sets a font.
    /// </summary>
    public Font Font
    {
      get { return FFont; }
      set { FFont = value; }
    }

    /// <summary>
    /// Serializes the style.
    /// </summary>
    /// <param name="writer">Writer object.</param>
    /// <remarks>
    /// This method is for internal use only.
    /// </remarks>
    public void Serialize(FRWriter writer)
    {
      Style s = writer.DiffObject as Style;
      
      writer.ItemName = "Style";
      writer.WriteStr("Name", Name);
      Border.Serialize(writer, "Border", s.Border);
      Fill.Serialize(writer, "Fill", s.Fill);
      TextFill.Serialize(writer, "TextFill", s.TextFill);
      if (!writer.AreEqual(Font, s.Font))
        writer.WriteValue("Font", Font);  
    }

    /// <summary>
    /// Deserializes the style.
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
    /// Creates exact copy of this <b>Style</b>.
    /// </summary>
    /// <returns>Copy of this style.</returns>
    public Style Clone()
    {
      Style result = new Style();
      result.Name = Name;
      result.Border = Border.Clone();
      result.Fill = Fill.Clone();
      result.Font = Font;
      result.TextFill = TextFill.Clone();
      return result;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Style"/> class with default settings.
    /// </summary>
    public Style()
    {
      Name = "";
      Border = new Border();
      Fill = new SolidFill();
      TextFill = new SolidFill(Color.Black);
      Font = Config.DesignerSettings.DefaultFont;
    }

  }
}
