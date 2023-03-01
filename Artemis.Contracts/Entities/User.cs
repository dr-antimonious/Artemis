namespace Artemis.Contracts.Entities
{
    public class User
    {
        private string id = default!;
        private string firstName = default!;
        private string addtnlNames = default!;
        private string lastName = default!;
        private DateTime dateOfBirth = default!;
        private char gender = default!;
        private string email = default!;
        private string phoneNumber = default!;
        private string password = default!;
        private bool isCoach = default!;
        private bool isManager = default!;
        private bool isDoctor = default!;
        private bool isShooter = default!;

        public User()
        {
        }

        public User(
            string firstName,
            string addtnlNames,
            string lastName,
            DateTime dateOfBirth,
            char gender,
            string email,
            string phoneNumber,
            string password,
            bool isCoach,
            bool isManager,
            bool isDoctor,
            bool isShooter)
            : this()
        {
            this.firstName = firstName;
            this.addtnlNames = addtnlNames;
            this.lastName = lastName;
            this.dateOfBirth = dateOfBirth;
            this.gender = gender;
            this.email = email;
            this.phoneNumber = phoneNumber;
            this.password = password;
            this.isCoach = isCoach;
            this.isManager = isManager;
            this.isDoctor = isDoctor;
            this.isShooter = isShooter;
        }

        public User(
            string id,
            string firstName,
            string addtnlNames,
            string lastName,
            DateTime dateOfBirth,
            char gender,
            string email,
            string phoneNumber,
            string password,
            bool isCoach,
            bool isManager,
            bool isDoctor,
            bool isShooter)
            : this(
                firstName,
                addtnlNames,
                lastName,
                dateOfBirth,
                gender,
                email,
                phoneNumber,
                password,
                isCoach,
                isManager,
                isDoctor,
                isShooter)
        {
            this.id = id;
        }

        public string Id
        {
            get => this.id;
            protected set => this.id = value;
        }

        public string FirstName
        {
            get => this.firstName;
            set => this.firstName = value;
        }

        public string AddtnlNames
        {
            get => this.addtnlNames;
            set => this.addtnlNames = value;
        }

        public string LastName
        {
            get => this.lastName;
            set => this.lastName = value;
        }

        public DateTime DateOfBirth
        {
            get => this.dateOfBirth;
            set => this.dateOfBirth = value;
        }

        public char Gender
        {
            get => this.gender;
            set => this.gender = value;
        }

        public string Email
        {
            get => this.email;
            set => this.email = value;
        }

        public string PhoneNumber
        {
            get => this.phoneNumber;
            set => this.phoneNumber = value;
        }

        public string Password
        {
            get => this.password;
            private set => this.password = value;
        }

        public bool IsCoach
        {
            get => this.isCoach;
            set => this.isCoach = value;
        }

        public bool IsManager
        {
            get => this.isManager;
            set => this.isManager = value;
        }

        public bool IsDoctor
        {
            get => this.isDoctor;
            set => this.isDoctor = value;
        }

        public bool IsShooter
        {
            get => this.isShooter;
            set => this.isShooter = value;
        }
    }
}
