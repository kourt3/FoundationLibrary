Namespace Keys.Person
    Public Enum TypeSex
        Man
        Woman
    End Enum
    Public Interface IHasFirstName
        Property FirstName As String
    End Interface
    Public Interface IHasLastName
        Property LastName As String
    End Interface
    Public Interface IHasBirthDate
        Property BirthDate As Date
    End Interface
    Public Interface IHasFullName
        ReadOnly Property FullName As String
    End Interface
    Public Interface IHasAge
        ReadOnly Property Age As Integer
    End Interface
    Public Interface IHasSex
        Property SexType As TypeSex
    End Interface

    Namespace Family
        Public Interface IHasMother(Of Tkey)
            Property Mother As Tkey
        End Interface
        Public Interface IHasFather(Of Tkey)
            Property Father As Tkey
        End Interface
        Public Interface IHasHusband(Of Tkey)
            Property Husband As Tkey
        End Interface
        Public Interface IHasWife(Of Tkey)
            Property Wife As Tkey
        End Interface
        Public Interface IHasSpouse(Of Tkey)
            Property Spouse As Tkey
        End Interface
    End Namespace

    Namespace Body
        ' ===== General =====

        Public Interface IHasBody
            Property Body As String
        End Interface

        Public Interface IHasHeight
            Property HeightCm As Decimal
        End Interface

        Public Interface IHasWeight
            Property WeightKg As Decimal
        End Interface

        Public Interface IHasBodyTemperature
            Property BodyTemperatureCelsius As Decimal
        End Interface

        Public Interface IHasBloodType
            Property BloodType As String
        End Interface

        Public Interface IHasSkinColor
            Property SkinColor As String
        End Interface

        Public Interface IHasBodyFatPercentage
            Property BodyFatPercentage As Decimal
        End Interface

        ' ===== Head =====

        Namespace Head

            Public Interface IHasHead(Of T)
                Property Head As T
            End Interface

            Public Interface IHasHair(Of T)
                Property Hair As T
            End Interface

            Public Interface IHasHairColor
                Property HairColor As String
            End Interface

            Public Interface IHasHairLength
                Property HairLengthCm As Decimal
            End Interface

            Public Interface IHasScalp(Of T)
                Property Scalp As T
            End Interface

            Public Interface IHasBrain(Of T)
                Property Brain As T
            End Interface

        End Namespace

        ' ===== Face =====

        Namespace Face

            Public Interface IHasFace(Of T)
                Property Face As T
            End Interface

            Public Interface IHasLeftEye(Of T)
                Property LeftEye As T
            End Interface

            Public Interface IHasRightEye(Of T)
                Property RightEye As T
            End Interface

            Public Interface IHasEyeColor
                Property EyeColor As String
            End Interface

            Public Interface IHasLeftEar(Of T)
                Property LeftEar As T
            End Interface

            Public Interface IHasRightEar(Of T)
                Property RightEar As T
            End Interface

            Public Interface IHasNose(Of T)
                Property Nose As T
            End Interface

            Public Interface IHasMouth(Of T)
                Property Mouth As T
            End Interface

            Public Interface IHasLips(Of T)
                Property Lips As T
            End Interface

            Public Interface IHasTongue(Of T)
                Property Tongue As T
            End Interface

            Public Interface IHasTeeth(Of T)
                Property Teeth As T
            End Interface

            Public Interface IHasJaw(Of T)
                Property Jaw As T
            End Interface

            Public Interface IHasEyebrows(Of T)
                Property Eyebrows As T
            End Interface

            Public Interface IHasEyelashes(Of T)
                Property Eyelashes As T
            End Interface

        End Namespace

        ' ===== Torso =====

        Namespace Torso

            Public Interface IHasNeck(Of T)
                Property Neck As T
            End Interface

            Public Interface IHasShoulders(Of T)
                Property Shoulders As T
            End Interface

            Public Interface IHasChest(Of T)
                Property Chest As T
            End Interface

            Public Interface IHasBack(Of T)
                Property Back As T
            End Interface

            Public Interface IHasAbdomen(Of T)
                Property Abdomen As T
            End Interface

            Public Interface IHasWaist(Of T)
                Property Waist As T
            End Interface

            Public Interface IHasPelvis(Of T)
                Property Pelvis As T
            End Interface

            Public Interface IHasHips(Of T)
                Property Hips As T
            End Interface

        End Namespace

        ' ===== Arms =====

        Namespace Arms

            Public Interface IHasLeftArm(Of T)
                Property LeftArm As T
            End Interface

            Public Interface IHasRightArm(Of T)
                Property RightArm As T
            End Interface

            Public Interface IHasElbow(Of T)
                Property Elbow As T
            End Interface

            Public Interface IHasWrist(Of T)
                Property Wrist As T
            End Interface

            Public Interface IHasLeftHand(Of T)
                Property LeftHand As T
            End Interface

            Public Interface IHasRightHand(Of T)
                Property RightHand As T
            End Interface

            Public Interface IHasFingers(Of T)
                Property Fingers As T
            End Interface

            Public Interface IHasThumb(Of T)
                Property Thumb As T
            End Interface

            Public Interface IHasNails(Of T)
                Property Nails As T
            End Interface

        End Namespace

        ' ===== Legs =====

        Namespace Legs

            Public Interface IHasLeftLeg(Of T)
                Property LeftLeg As T
            End Interface

            Public Interface IHasRightLeg(Of T)
                Property RightLeg As T
            End Interface

            Public Interface IHasThigh(Of T)
                Property Thigh As T
            End Interface

            Public Interface IHasKnee(Of T)
                Property Knee As T
            End Interface

            Public Interface IHasCalf(Of T)
                Property Calf As T
            End Interface

            Public Interface IHasAnkle(Of T)
                Property Ankle As T
            End Interface

            Public Interface IHasLeftFoot(Of T)
                Property LeftFoot As T
            End Interface

            Public Interface IHasRightFoot(Of T)
                Property RightFoot As T
            End Interface

            Public Interface IHasToes(Of T)
                Property Toes As T
            End Interface

            Public Interface IHasHeel(Of T)
                Property Heel As T
            End Interface

        End Namespace

        ' ===== Internal Organs =====

        Namespace Organs

            Public Interface IHasHeart(Of T)
                Property Heart As T
            End Interface

            Public Interface IHasLungs(Of T)
                Property Lungs As T
            End Interface

            Public Interface IHasLiver(Of T)
                Property Liver As T
            End Interface

            Public Interface IHasStomach(Of T)
                Property Stomach As T
            End Interface

            Public Interface IHasKidneys(Of T)
                Property Kidneys As T
            End Interface

            Public Interface IHasIntestines(Of T)
                Property Intestines As T
            End Interface

            Public Interface IHasPancreas(Of T)
                Property Pancreas As T
            End Interface

            Public Interface IHasSpleen(Of T)
                Property Spleen As T
            End Interface

            Public Interface IHasBladder(Of T)
                Property Bladder As T
            End Interface

            Public Interface IHasGallbladder(Of T)
                Property Gallbladder As T
            End Interface

            Public Interface IHasThyroid(Of T)
                Property Thyroid As T
            End Interface

            Public Interface IHasReproductiveOrgans(Of T)
                Property ReproductiveOrgans As T
            End Interface

        End Namespace

        ' ===== Measurements =====

        Namespace Measurements

            Public Interface IHasChestCircumference
                Property ChestCircumferenceCm As Decimal
            End Interface

            Public Interface IHasWaistCircumference
                Property WaistCircumferenceCm As Decimal
            End Interface

            Public Interface IHasHipCircumference
                Property HipCircumferenceCm As Decimal
            End Interface

            Public Interface IHasArmLength
                Property ArmLengthCm As Decimal
            End Interface

            Public Interface IHasLegLength
                Property LegLengthCm As Decimal
            End Interface

            Public Interface IHasFootLength
                Property FootLengthCm As Decimal
            End Interface

            Public Interface IHasHeadCircumference
                Property HeadCircumferenceCm As Decimal
            End Interface

        End Namespace
    End Namespace
End Namespace

