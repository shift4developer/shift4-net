namespace Shift4.Response
{
    public class Expandable<T>
    {
        public string Id { get; set;}
        public T ExpandedObject {get; set;}

        public bool Expanded {
            get {
                return ExpandedObject != null;
            } 
        }
    }
}