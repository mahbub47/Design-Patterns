using System;
using System.Collections.Generic;
using System.Text;

namespace Design_Patterns.Creational_Design_Patterns
{
    public class AbstractFactory
    {
        public interface IButton
        {
            void Paint();
            void OnClick();
        }

        public interface ICheckBox
        {
            void Paint();
            void OnSelect();
        }

        public class WindowsButton : IButton
        {
            public void OnClick()
            {
                Console.WriteLine("Window button clicked!");
            }

            public void Paint()
            {
                Console.WriteLine("painting windows button!");
            }
        }

        public class WindowsCheckBox : ICheckBox
        {
            public void OnSelect()
            {
                Console.WriteLine("Windows Checkbox selected!");
            }

            public void Paint()
            {
                Console.WriteLine("painting windows checkbox");
            }
        }

        public class MacButton : IButton
        {
            public void OnClick()
            {
                Console.WriteLine("mac button clicked!");
            }

            public void Paint()
            {
                Console.WriteLine("painting mac os button!");
            }
        }

        public class MacCheckbox : ICheckBox
        {
            public void OnSelect()
            {
                Console.WriteLine("mac checkbox selected!");
            }

            public void Paint()
            {
                Console.WriteLine("painting mac os checkbox!");
            }
        }

        public interface IGUIFactory
        {
            IButton CreateButton();
            ICheckBox CreateCheckBox();
        }

        public class WindowsGUIFactory : IGUIFactory
        {
            public IButton CreateButton()
            {
                return new WindowsButton();
            }

            public ICheckBox CreateCheckBox()
            {
               return new WindowsCheckBox();
            }
        }

        public class MacGUIFactory : IGUIFactory
        {
            public IButton CreateButton()
            {
                return new MacButton();
            }

            public ICheckBox CreateCheckBox()
            {
                return new MacCheckbox();
            }
        }

        public class Application
        {
            private IButton _button;
            private ICheckBox _checkBox;

            public Application(IGUIFactory factory)
            {
                _button = factory.CreateButton();
                _checkBox = factory.CreateCheckBox();
            }

            public void Render()
            {
                _button.Paint();
                _checkBox.Paint();
            }
        }

        public class Program
        {
            //public static void Main(string[] args)
            //{
            //    Application app;
            //    app = new Application(new MacGUIFactory());
            //    app.Render();
            //}
        }
    }
}
