using System;
using System.Collections.Generic;
using System.Text;

namespace Design_Patterns.Structural_Design_Patterns
{
    public class DecoratorPattern
    {
        public interface ITextView
        {
            void Render();
        }

        public class PlainTextView : ITextView
        {
            private string _text;

            public PlainTextView(string text)
            {
                _text = text;
            }

            public void Render()
            {
                Console.Write($"{_text}");
            }
        }

        public abstract class DecoratorClass : ITextView
        {
            protected ITextView _inner;

            public DecoratorClass(ITextView inner)
            {
                _inner = inner;
            }

            public abstract void Render();
        }

        public class BoldText : DecoratorClass
        {
            public BoldText(ITextView textView) : base(textView) { }
            public override void Render()
            {
                Console.Write("<b>");
                _inner.Render();
                Console.Write("</b>");
            }
        }

        public class ItalicText : DecoratorClass
        {
            public ItalicText(ITextView textView) : base(textView) { }
            public override void Render()
            {
                Console.Write("<i>");
                _inner.Render();
                Console.Write("</i>");
            }
        }

        public class UnderlinedText : DecoratorClass
        {
            public UnderlinedText(ITextView textView) : base(textView) { }

            public override void Render()
            {
                Console.Write("<u>");
                _inner.Render();
                Console.Write("</u>");
            }
        }

        public class TextEditor
        {
            public static void Main(string[] args)
            {
                PlainTextView text = new PlainTextView("Hello brothers!");

                Console.WriteLine();
                Console.WriteLine("Plain Text: ");
                text.Render();

                Console.WriteLine();
                Console.WriteLine("Bold Text");
                var boldText = new BoldText(text);
                boldText.Render();

                Console.WriteLine();
                Console.WriteLine("Italic + Underlined Text");
                var italicUnderlinedText = new UnderlinedText(new ItalicText(text));
                italicUnderlinedText.Render();
            }
        }
    }
}
